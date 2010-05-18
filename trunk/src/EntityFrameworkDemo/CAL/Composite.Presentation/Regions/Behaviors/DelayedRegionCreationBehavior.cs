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
using System.Globalization;
using System.Windows;
using Microsoft.Practices.Composite.Presentation.Properties;
using Microsoft.Practices.Composite.Regions;

namespace Microsoft.Practices.Composite.Presentation.Regions.Behaviors
{
    /// <summary>
    /// Behavior that creates a new <see cref="IRegion"/>, when the control that will host the <see cref="IRegion"/> (see <see cref="TargetElement"/>)
    /// is added to the VisualTree. This behavior will use the <see cref="RegionAdapterMappings"/> class to find the right type of adapter to create
    /// the region. After the region is created, this behavior will detach. 
    /// </summary>
    /// <remarks>
    /// Attached property value inheritance is not available in Silverlight, so the current approach walks up the visual tree when requesting a region from a region manager.
    /// The <see cref="RegionManagerRegistrationBehavior"/> is now responsible for walking up the Tree. 
    /// </remarks>
    public class DelayedRegionCreationBehavior
    {
        private readonly RegionAdapterMappings regionAdapterMappings;
        private WeakReference elementWeakReference;
        private bool regionCreated;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelayedRegionCreationBehavior"/> class.
        /// </summary>
        /// <param name="regionAdapterMappings">
        /// The region adapter mappings, that are used to find the correct adapter for 
        /// a given controltype. The controltype is determined by the <see name="TargetElement"/> value. 
        /// </param>
        public DelayedRegionCreationBehavior(RegionAdapterMappings regionAdapterMappings)
        {
            this.regionAdapterMappings = regionAdapterMappings;
            RegionManagerAccessor = new DefaultRegionManagerAccessor();
        }

        /// <summary>
        /// Sets a class that interfaces between the <see cref="RegionManager"/> 's static properties/events and this behavior,
        /// so this behavior can be tested in isolation. 
        /// </summary>
        /// <value>The region manager accessor.</value>
        public IRegionManagerAccessor RegionManagerAccessor { get; set; }

        /// <summary>
        /// The element that will host the Region. 
        /// </summary>
        /// <value>The target element.</value>
        public DependencyObject TargetElement
        {
            get { return elementWeakReference != null ? elementWeakReference.Target as DependencyObject : null; }
            set { elementWeakReference = new WeakReference(value); }
        }

        /// <summary>
        /// Start monitoring the <see cref="RegionManager"/> and the <see cref="TargetElement"/> to detect when the <see cref="TargetElement"/> becomes
        /// part of the Visual Tree. When that happens, the Region will be created and the behavior will <see cref="Detach"/>.
        /// </summary>
        public void Attach()
        {
            RegionManagerAccessor.UpdatingRegions += OnUpdatingRegions;
            WireUpTargetElement();
        }

        /// <summary>
        /// Stop monitoring the <see cref="RegionManager"/> and the  <see cref="TargetElement"/>, so that this behavior can be garbage collected. 
        /// </summary>
        public void Detach()
        {
            RegionManagerAccessor.UpdatingRegions -= OnUpdatingRegions;
            UnWireTargetElement();
        }

        /// <summary>
        /// Called when the <see cref="RegionManager"/> is updating it's <see cref="RegionManager.Regions"/> collection. 
        /// </summary>
        /// <remarks>
        /// This method has to be public, because it has to be callable using weak references in silverlight and other partial trust environments.
        /// </remarks>
        /// <param name="sender">The <see cref="RegionManager"/>. </param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2109:ReviewVisibleEventHandlers", Justification = "This has to be public in order to work with weak references in partial trust or Silverlight environments.")]
        public void OnUpdatingRegions(object sender, EventArgs e)
        {
            TryCreateRegion();
        }

        private void TryCreateRegion()
        {
            DependencyObject targetElement = TargetElement;
            if (targetElement == null)
            {
                Detach();
                return;
            }

            if (targetElement.CheckAccess())
            {
                Detach();

                if (!regionCreated)
                {
                    string regionName = RegionManagerAccessor.GetRegionName(targetElement);
                    CreateRegion(targetElement, regionName);
                    regionCreated = true;
                }
            }
        }

        /// <summary>
        /// Method that will create the region, by calling the right <see cref="IRegionAdapter"/>. 
        /// </summary>
        /// <param name="targetElement">The target element that will host the <see cref="IRegion"/>.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <returns>The created <see cref="IRegion"/></returns>
        protected virtual IRegion CreateRegion(DependencyObject targetElement, string regionName)
        {
            try
            {
                // Build the region
                IRegionAdapter regionAdapter = regionAdapterMappings.GetMapping(targetElement.GetType());
                IRegion region = regionAdapter.Initialize(targetElement, regionName);

                return region;
            }
            catch (Exception ex)
            {
                throw new RegionCreationException(string.Format(CultureInfo.CurrentCulture, Resources.RegionCreationException, regionName, ex), ex);
            }
        }

        private void ElementLoaded(object sender, RoutedEventArgs e)
        {
            UnWireTargetElement();
            TryCreateRegion();
        }

        private void WireUpTargetElement()
        {
            var element = TargetElement as FrameworkElement;
            if (element != null)
            {
                element.Loaded += ElementLoaded;
            }
        }

        private void UnWireTargetElement()
        {
            var element = TargetElement as FrameworkElement;
            if (element != null)
            {
                element.Loaded -= ElementLoaded;
            }
        }
    }
}