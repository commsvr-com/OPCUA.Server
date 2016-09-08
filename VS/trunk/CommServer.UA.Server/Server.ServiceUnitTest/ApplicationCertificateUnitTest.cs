
using CAS.UA.Server.ServerConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opc.Ua;
using System.Security.Cryptography.X509Certificates;

namespace CAS.CommServer.UA.Server.Service.UnitTest
{
  [TestClass]
  public class ApplicationCertificateUnitTest
  {
    [TestMethod]
    [ExpectedException(typeof(ServiceResultException))]
    public void CheckApplicationInstanceCertificateNoGeneratorTestMethod1()
    {
      ApplicationConfiguration _newConfiguration = new ApplicationConfigurationTestClass();
      X509Certificate2 _certificate = ApplicationCertificate.CheckApplicationInstanceCertificate(_newConfiguration, 1028, (x, y) => true, false);
    }
    [TestMethod]
    public void MyTestMethod()
    {
    }
    private class ApplicationConfigurationTestClass : ApplicationConfiguration
    {

    }
  }
}
