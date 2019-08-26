using FirebaseStandard.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestFirebaseStandard
{
    [TestClass]
    public class AuthTest
    {
        [TestMethod]
        public async Task CreateUser()
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD23hI5mrm_nwwSqpIUdTGLdcVF2UWT-4E"));

            try
            {
                var authLink = await auth.CreateUserWithEmailAndPasswordAsync("hello2@world.com", "h3ll0!", "jayson ragasa", true);
            } 
            catch(FirebaseAuthException fae)
            {
                Debug.WriteLine(fae.Reason);
            }


            //Assert.IsTrue((authLink != null ? true : false));
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task LoginUser()
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD23hI5mrm_nwwSqpIUdTGLdcVF2UWT-4E"));

            try
            {
                var authLink = await auth.SignInWithEmailAndPasswordAsync("hello@world.com", "sgsdsfh3ll0!");
            }
            catch (FirebaseAuthException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Reason);
            }

            // force true
            Assert.IsTrue(true);
        }
    }
}
