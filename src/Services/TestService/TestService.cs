using System.Collections.Generic;
using System.Linq;

namespace Services.TestService
{
    public class TestService : ITestService
    {

        /// <summary>
        /// Get the first int of the list
        /// </summary>
        /// <returns>a int with the result</returns>
        public int GetFirst()
        {
            var testRepository = new List<int> { 10,9,8,7,6,5,4,3,2,1,0 };

            return testRepository.FirstOrDefault();
        }
    }
}
