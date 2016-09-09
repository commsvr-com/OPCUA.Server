
using CAS.UA.Server.ServerConfiguration;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opc.Ua;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Fakes;

namespace CAS.CommServer.UA.Server.Service.UnitTest
{
  [TestClass]
  public class ApplicationCertificateUnitTest
  {
    [TestMethod]
    [ExpectedException(typeof(ServiceResultException))]
    public void CheckApplicationInstanceCertificateNoGeneratorTestMethod1()
    {
      using (Main _main = new Main())
      {
        _main.CreateDefaultConfiguration();
        CASConfiguration _default = _main.Configuration;
        Assert.IsNotNull(_default);
        X509Certificate2 _certificate = ApplicationCertificate.CheckApplicationInstanceCertificate(_default, 1028, (x, y) => true, false);
      }
    }
    [TestMethod]
    public void DisplayUaTcpImplementationForDefaultConfigurationTest()
    {
      using (Main _main = new Main())
      {
        _main.CreateDefaultConfiguration();
        CASConfiguration _default = _main.Configuration;
        string _result = null;
        string _formText = "Form text";
        ApplicationCertificate.DisplayUaTcpImplementation(x => _result = x, _formText, _default);
        Assert.IsNull(_result);
      }
    }
    [TestMethod]
    public void DisplayUaTcpImplementationForDemoConfigurationTest()
    {
      using (Main _main = new Main())
      {
        _main.ReadConfiguration(AssemblyInitializeClass.CASConfigurationFileInfo);
        Assert.IsNotNull(_main.Configuration);
        Assert.AreEqual<int>(0, _main.Configuration.TransportConfigurations.Count); //TODO the configuration contains empty array ??!
        string _result = null;
        string _formText = "Form text";
        ApplicationCertificate.DisplayUaTcpImplementation(x => _result = x, _formText, _main.Configuration);
        Assert.IsNull(_result);
      }
    }
    /// <summary>
    /// Handles the certificate validation error test method.
    /// </summary>
    /// <remarks>
    /// An instance of the <see cref="CertificateValidationEventArgs"/> cannot be created becose the constructor is not visible.
    /// Try to figure out how to create thsi instance indarectly.
    /// </remarks>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void HandleCertificateValidationErrorTestMethod()
    {
      ApplicationCertificate.HandleCertificateValidationError(null);
    }
    [TestMethod]
    public void OverrideUaTcpImplementationTest()
    {
      using (ShimsContext.Create())
      {
        System.Fakes.ShimEnvironment.GetCommandLineArgs = () => { return new string[] { "Application name", "-uaTcpAnsiC" }; };
        ApplicationConfiguration _newTcpSettings = new ApplicationConfiguration()
        {
          TransportConfigurations = new TransportConfigurationCollection(new TransportConfiguration[] { new TransportConfiguration() { TypeName = "TypeName", UriScheme = Utils.UriSchemeOpcTcp } })
        };
        ApplicationCertificate.OverrideUaTcpImplementation(_newTcpSettings);
        Assert.IsNotNull(_newTcpSettings.TransportConfigurations);
        Assert.AreEqual<int>(1, _newTcpSettings.TransportConfigurations.Count);
        Assert.AreEqual<string>(Utils.UaTcpBindingNativeStack, _newTcpSettings.TransportConfigurations[0].TypeName);
      }
    }
  }
}

