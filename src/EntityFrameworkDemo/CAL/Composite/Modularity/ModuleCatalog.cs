//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Markup;
using Microsoft.Practices.Composite.Properties;

namespace Microsoft.Practices.Composite.Modularity
{
    /// <summary>
    /// The <see cref="ModuleCatalog"/> holds information about the modules that can be used by the 
    /// application. Each module is described in a <see cref="ModuleInfo"/> class, that records the 
    /// name, type and location of the module. 
    /// 
    /// It also verifies that the <see cref="ModuleCatalog"/> is internally valid. That means that
    /// it does not have:
    /// <list>
    ///     <item>Circular dependencies</item>
    ///     <item>Missing dependencies</item>
    ///     <item>
    ///         Invalid dependencies, such as a Module that's loaded at startup that depends on a module 
    ///         that might need to be retrieved.
    ///     </item>
    /// </list>
    /// The <see cref="ModuleCatalog"/> also serves as a baseclass for more specialized Catalogs .
    /// </summary>
    [ContentProperty("Items")]
    public class ModuleCatalog : IModuleCatalog
    {
        private readonly ModuleCatalogItemCollection items;
        private bool isLoaded;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleCatalog"/> class.
        /// </summary>
        public ModuleCatalog()
        {
            items = new ModuleCatalogItemCollection();
            items.CollectionChanged += ItemsCollectionChanged;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleCatalog"/> class while providing an 
        /// initial list of <see cref="ModuleInfo"/>s.
        /// </summary>
        /// <param name="modules">The initial list of modules.</param>
        public ModuleCatalog(IEnumerable<ModuleInfo> modules)
            : this()
        {
            foreach (var moduleInfo in modules)
            {
                Items.Add(moduleInfo);
            }
        }

        /// <summary>
        /// Gets the items in the <see cref="ModuleCatalog"/>. This property is mainly used to add <see cref="ModuleInfoGroup"/>s or 
        /// <see cref="ModuleInfo"/>s through XAML. 
        /// </summary>
        /// <value>The items in the catalog.</value>
        public Collection<IModuleCatalogItem> Items
        {
            get { return items; }
        }

        /// <summary>
        /// Gets all the <see cref="ModuleInfo"/> classes that are in the <see cref="ModuleCatalog"/>, regardless 
        /// if they are within a <see cref="ModuleInfoGroup"/> or not. 
        /// </summary>
        /// <value>The modules.</value>
        public virtual IEnumerable<ModuleInfo> Modules
        {
            get
            {
                return GrouplessModules.Union(Groups.SelectMany(g => g));
            }
        }

        /// <summary>
        /// Gets the <see cref="ModuleInfoGroup"/>s that have been added to the <see cref="ModuleCatalog"/>. 
        /// </summary>
        /// <value>The groups.</value>
        public IEnumerable<ModuleInfoGroup> Groups
        {
            get
            {
                return Items.OfType<ModuleInfoGroup>();
            }
        }

        /// <summary>
        /// Gets or sets a value that remembers whether the <see cref="ModuleCatalog"/> has been validated already. 
        /// </summary>
        protected bool Validated { get; set; }

        /// <summary>
        /// Returns the list of <see cref="ModuleInfo"/>s that are not contained within any <see cref="ModuleInfoGroup"/>. 
        /// </summary>
        /// <value>The groupless modules.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Groupless")]
        protected IEnumerable<ModuleInfo> GrouplessModules
        {
            get
            {
                return Items.OfType<ModuleInfo>();
            }
        }

        /// <summary>
        /// Creates a <see cref="ModuleCatalog"/> from XAML.
        /// </summary>
        /// <param name="xamlStream"><see cref="Stream"/> that contains the XAML declaration of the catalog.</param>
        /// <returns>An instance of <see cref="ModuleCatalog"/> built from the XAML.</returns>
        public static ModuleCatalog CreateFromXaml(Stream xamlStream)
        {
            if (xamlStream == null)
            {
                throw new ArgumentNullException("xamlStream");
            }

#if SILVERLIGHT
            string xaml;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(xamlStream))
            {
                xaml = reader.ReadToEnd();
            }
            return XamlReader.Load(xaml) as ModuleCatalog;
#else
            return XamlReader.Load(xamlStream) as ModuleCatalog;
#endif
        }

        /// <summary>
        /// Creates a <see cref="ModuleCatalog"/> from a XAML included as an Application Resource.
        /// </summary>
        /// <param name="builderResourceUri">Relative <see cref="Uri"/> that identifies the XAML included as an Application Resource.</param>
        /// <returns>An instance of <see cref="ModuleCatalog"/> build from the XAML.</returns>
        public static ModuleCatalog CreateFromXaml(Uri builderResourceUri)
        {
            var streamInfo = System.Windows.Application.GetResourceStream(builderResourceUri);

            if ((streamInfo != null) && (streamInfo.Stream != null))
            {
                return CreateFromXaml(streamInfo.Stream);
            }

            return null;
        }

        /// <summary>
        /// Loads the catalog if necessary.
        /// </summary>
        public void Load()
        {
            isLoaded = true;
            InnerLoad();
        }

        /// <summary>
        /// Return the list of <see cref="ModuleInfo"/>s that <paramref name="moduleInfo"/> depends on.
        /// </summary>
        /// <remarks>
        /// If  the <see cref="ModuleCatalog"/> was not yet validated, this method will call <see cref="Validate"/>.
        /// </remarks>
        /// <param name="moduleInfo">The <see cref="ModuleInfo"/> to get the </param>
        /// <returns>An enumeration of <see cref="ModuleInfo"/> that <paramref name="moduleInfo"/> depends on.</returns>
        public virtual IEnumerable<ModuleInfo> GetDependentModules(ModuleInfo moduleInfo)
        {
            EnsureCatalogValidated();

            return GetDependentModulesInner(moduleInfo);
        }

        /// <summary>
        /// Adds a <see cref="ModuleInfo"/> to the <see cref="ModuleCatalog"/>.
        /// </summary>
        /// <param name="moduleInfo">The <see cref="ModuleInfo"/> to add.</param>
        /// <returns>The <see cref="ModuleCatalog"/> for easily adding multiple modules.</returns>
        public virtual IModuleCatalog AddModule(ModuleInfo moduleInfo)
        {
            Items.Add(moduleInfo);
            return this;
        }

        /// <summary>
        /// Returns a list of <see cref="ModuleInfo"/>s that contain both the <see cref="ModuleInfo"/>s in 
        /// <paramref name="modules"/>, but also all the modules they depend on. 
        /// </summary>
        /// <param name="modules">The modules to get the dependencies for.</param>
        /// <returns>
        /// A list of <see cref="ModuleInfo"/> that contains both all <see cref="ModuleInfo"/>s in <paramref name="modules"/>
        /// but also all the <see cref="ModuleInfo"/> they depend on.
        /// </returns>
        public virtual IEnumerable<ModuleInfo> CompleteListWithDependencies(IEnumerable<ModuleInfo> modules)
        {
            if (modules == null)
            {
                throw new ArgumentNullException("modules");
            }

            EnsureCatalogValidated();

            var completeList = new List<ModuleInfo>();
            List<ModuleInfo> pendingList = modules.ToList();
            while (pendingList.Count > 0)
            {
                ModuleInfo moduleInfo = pendingList[0];

                foreach (var dependency in GetDependentModules(moduleInfo))
                {
                    if (!completeList.Contains(dependency) && !pendingList.Contains(dependency))
                    {
                        pendingList.Add(dependency);
                    }
                }

                pendingList.RemoveAt(0);
                completeList.Add(moduleInfo);
            }

            IEnumerable<ModuleInfo> sortedList = Sort(completeList);
            return sortedList;
        }

        /// <summary>
        /// Validates the <see cref="ModuleCatalog"/>.
        /// </summary>
        /// <exception cref="ModularityException">When validation of the <see cref="ModuleCatalog"/> fails.</exception>
        public virtual void Validate()
        {
            ValidateUniqueModules();
            ValidateDependencyGraph();
            ValidateCrossGroupDependencies();
            ValidateDependenciesInitializationMode();

            Validated = true;
        }

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="ModuleCatalog"/> instance with the added module.</returns>
        public ModuleCatalog AddModule(Type moduleType, params string[] dependsOn)
        {
            return AddModule(moduleType, InitializationMode.WhenAvailable, dependsOn);
        }

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="ModuleCatalog"/> instance with the added module.</returns>
        public ModuleCatalog AddModule(Type moduleType, InitializationMode initializationMode, params string[] dependsOn)
        {
            return AddModule(moduleType.Name, moduleType.AssemblyQualifiedName, initializationMode, dependsOn);
        }

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="ModuleCatalog"/> instance with the added module.</returns>
        public ModuleCatalog AddModule(string moduleName, string moduleType, params string[] dependsOn)
        {
            return AddModule(moduleName, moduleType, InitializationMode.WhenAvailable, dependsOn);
        }

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="ModuleCatalog"/> instance with the added module.</returns>
        public ModuleCatalog AddModule(string moduleName, string moduleType, InitializationMode initializationMode, params string[] dependsOn)
        {
            return AddModule(moduleName, moduleType, null, initializationMode, dependsOn);
        }

        /// <summary>
        /// Adds a groupless <see cref="ModuleInfo"/> to the catalog.
        /// </summary>
        /// <param name="moduleName">Name of the module to be added.</param>
        /// <param name="moduleType"><see cref="Type"/> of the module to be added.</param>
        /// <param name="refValue">Reference to the location of the module to be added assembly.</param>
        /// <param name="initializationMode">Stage on which the module to be added will be initialized.</param>
        /// <param name="dependsOn">Collection of module names (<see cref="ModuleInfo.ModuleName"/>) of the modules on which the module to be added logically depends on.</param>
        /// <returns>The same <see cref="ModuleCatalog"/> instance with the added module.</returns>
        public ModuleCatalog AddModule(string moduleName, string moduleType, string refValue, InitializationMode initializationMode, params string[] dependsOn)
        {
            if (moduleName == null)
            {
                throw new ArgumentNullException("moduleName");
            }

            if (moduleType == null)
            {
                throw new ArgumentNullException("moduleType");
            }

            var moduleInfo = new ModuleInfo(moduleName, moduleType);
            moduleInfo.DependsOn.AddRange(dependsOn);
            moduleInfo.InitializationMode = initializationMode;
            moduleInfo.Ref = refValue;
            Items.Add(moduleInfo);
            return this;
        }

        /// <summary>
        /// Initializes the catalog, which may load and validate the modules.
        /// </summary>
        /// <exception cref="ModularityException">When validation of the <see cref="ModuleCatalog"/> fails, because this method calls <see cref="Validate"/>.</exception>
        public virtual void Initialize()
        {
            if (!isLoaded)
            {
                Load();
            }

            Validate();
        }

        /// <summary>
        /// Creates and adds a <see cref="ModuleInfoGroup"/> to the catalog.
        /// </summary>
        /// <param name="initializationMode">Stage on which the module group to be added will be initialized.</param>
        /// <param name="refValue">Reference to the location of the module group to be added.</param>
        /// <param name="moduleInfos">Collection of <see cref="ModuleInfo"/> included in the group.</param>
        /// <returns><see cref="ModuleCatalog"/> with the added module group.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Infos")]
        public virtual ModuleCatalog AddGroup(InitializationMode initializationMode, string refValue, params ModuleInfo[] moduleInfos)
        {
            var newGroup = new ModuleInfoGroup();
            newGroup.InitializationMode = initializationMode;
            newGroup.Ref = refValue;

            foreach (var info in moduleInfos)
            {
                newGroup.Add(info);
            }

            items.Add(newGroup);

            return this;
        }

        /// <summary>
        /// Checks for cyclic dependencies, by calling the dependencysolver. 
        /// </summary>
        /// <param name="modules">the.</param>
        /// <returns></returns>
        protected static string[] SolveDependencies(IEnumerable<ModuleInfo> modules)
        {
            var solver = new ModuleDependencySolver();

            foreach (var data in modules)
            {
                solver.AddModule(data.ModuleName);

                if (data.DependsOn != null)
                {
                    foreach (var dependency in data.DependsOn)
                    {
                        solver.AddDependency(data.ModuleName, dependency);
                    }
                }
            }

            if (solver.ModuleCount > 0)
            {
                return solver.Solve();
            }

            return new string[0];
        }

        /// <summary>
        /// Ensures that all the dependencies within <paramref name="modules"/> refer to <see cref="ModuleInfo"/>s
        /// within that list.
        /// </summary>
        /// <param name="modules">The modules to validate modules for.</param>
        /// <exception cref="ModularityException">
        /// Throws if a <see cref="ModuleInfo"/> in <paramref name="modules"/> depends on a module that's 
        /// not in <paramref name="modules"/>.
        /// </exception>
        protected static void ValidateDependencies(IEnumerable<ModuleInfo> modules)
        {
            var moduleNames = modules.Select(m => m.ModuleName).ToList();
            foreach (var moduleInfo in modules)
            {
                if (moduleInfo.DependsOn != null && moduleInfo.DependsOn.Except(moduleNames).Any())
                {
                    throw new ModularityException(
                        moduleInfo.ModuleName,
                        String.Format(CultureInfo.CurrentCulture, Resources.ModuleDependenciesNotMetInGroup, moduleInfo.ModuleName));
                }
            }
        }

        /// <summary>
        /// Does the actual work of loading the catalog.  The base implementation does nothing.
        /// </summary>
        protected virtual void InnerLoad()
        {
        }

        /// <summary>
        /// Sorts a list of <see cref="ModuleInfo"/>s. This method is called by <see cref="CompleteListWithDependencies"/>
        /// to return a sorted list. 
        /// </summary>
        /// <param name="modules">The <see cref="ModuleInfo"/>s to sort.</param>
        /// <returns>Sorted list of <see cref="ModuleInfo"/>s</returns>
        protected virtual IEnumerable<ModuleInfo> Sort(IEnumerable<ModuleInfo> modules)
        {
            foreach (var moduleName in SolveDependencies(modules))
            {
                yield return modules.First(m => m.ModuleName == moduleName);
            }
        }
        
        /// <summary>
        /// Makes sure all modules have an Unique name. 
        /// </summary>
        /// <exception cref="DuplicateModuleException">
        /// Thrown if the names of one or more modules are not unique. 
        /// </exception>
        protected virtual void ValidateUniqueModules()
        {
            List<string> moduleNames = Modules.Select(m => m.ModuleName).ToList();

            string duplicateModule = moduleNames.FirstOrDefault(
                m => moduleNames.Count(m2 => m2 == m) > 1);

            if (duplicateModule != null)
            {
                throw new DuplicateModuleException(duplicateModule, String.Format(CultureInfo.CurrentCulture, Resources.DuplicatedModule, duplicateModule));
            }
        }

        /// <summary>
        /// Ensures that there are no cyclic dependencies. 
        /// </summary>
        protected virtual void ValidateDependencyGraph()
        {
            SolveDependencies(Modules);
        }

        /// <summary>
        /// Ensures that there are no dependencies between modules on different groups.
        /// </summary>
        /// <remarks>
        /// A groupless module can only depend on other groupless modules.
        /// A module within a group can depend on other modules within the same group and/or on groupless modules.
        /// </remarks>
        protected virtual void ValidateCrossGroupDependencies()
        {
            ValidateDependencies(GrouplessModules);
            foreach (var group in Groups)
            {
                ValidateDependencies(GrouplessModules.Union(group));
            }
        }

        /// <summary>
        /// Ensures that there are no modules marked to be loaded <see cref="InitializationMode.WhenAvailable"/>
        /// depending on modules loaded <see cref="InitializationMode.OnDemand"/>
        /// </summary>
        protected virtual void ValidateDependenciesInitializationMode()
        {
            ModuleInfo moduleInfo = Modules.FirstOrDefault(
                m =>
                m.InitializationMode == InitializationMode.WhenAvailable &&
                GetDependentModulesInner(m)
                    .Any(dependency => dependency.InitializationMode == InitializationMode.OnDemand));

            if (moduleInfo != null)
            {
                throw new ModularityException(
                    moduleInfo.ModuleName,
                    String.Format(CultureInfo.CurrentCulture, Resources.StartupModuleDependsOnAnOnDemandModule, moduleInfo.ModuleName));
            }
        }

        /// <summary>
        /// Returns the <see cref="ModuleInfo"/> on which the received module dependens on.
        /// </summary>
        /// <param name="moduleInfo">Module whose dependant modules are requested.</param>
        /// <returns>Collection of <see cref="ModuleInfo"/> dependants of <paramref name="moduleInfo"/>.</returns>
        protected virtual IEnumerable<ModuleInfo> GetDependentModulesInner(ModuleInfo moduleInfo)
        {
            return Modules.Where(dependantModule => moduleInfo.DependsOn.Contains(dependantModule.ModuleName));
        }

        /// <summary>
        /// Ensures that the catalog is validated.
        /// </summary>
        protected virtual void EnsureCatalogValidated()
        {
            if (!Validated)
            {
                Validate();
            }
        }

        private void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Validated)
            {
                EnsureCatalogValidated();
            }
        }

        private class ModuleCatalogItemCollection : Collection<IModuleCatalogItem>, INotifyCollectionChanged
        {
            public event NotifyCollectionChangedEventHandler CollectionChanged;

            protected override void InsertItem(int index, IModuleCatalogItem item)
            {
                base.InsertItem(index, item);

                OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
            }

            protected void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs eventArgs)
            {
                if (CollectionChanged != null)
                {
                    CollectionChanged(this, eventArgs);
                }
            }
        }
    }
}
