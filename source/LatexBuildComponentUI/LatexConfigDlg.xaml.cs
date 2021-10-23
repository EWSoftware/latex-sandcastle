using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using System.Xml.Linq;

using Sandcastle.Core.BuildAssembler;

namespace Cuda.Latex
{
    /// <summary>
    /// This is used to set the LaTeX build component configuration options
    /// </summary>
    public partial class LatexConfigDlg : Window
    {
        #region Build component configuration editor factory for MEF
        //=====================================================================

        /// <summary>
        /// This allows editing of the component configuration
        /// </summary>
        [ConfigurationEditorExport("LaTeX Build Component")]
        public sealed class BuildComponentFactory : IConfigurationEditor
        {
            /// <inheritdoc />
            public bool EditConfiguration(XElement configuration, CompositionContainer container)
            {
                var dlg = new LatexConfigDlg(configuration);

                return dlg.ShowDialog() ?? false;
            }
        }
        #endregion

        #region Private data members
        //=====================================================================

        private readonly XElement configuration;

        #endregion

        #region Constructor
        //=====================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">The current configuration element</param>
        public LatexConfigDlg(XElement configuration)
        {
            InitializeComponent();

            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            if(Int32.TryParse(configuration.Element("fontSize").Attribute("value").Value, out int fontSize))
                cboFontSize.SelectedIndex = fontSize;
            else
                cboFontSize.SelectedIndex = 3;
        }
        #endregion

        #region Event handlers
        //=====================================================================

        /// <summary>
        /// Save changes to the configuration
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            configuration.Element("fontSize").Attribute("value").SetValue(cboFontSize.SelectedIndex);

            this.DialogResult = true;
            this.Close();
        }
        #endregion
    }
}
