using CarFactoryMVC.Entities;
using CarFactoryMVC.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;

namespace CarFactoryMVC_Test
{
    public class OwnerRepoTests
    {
        [Fact]
        public void GetAllOwners_returnOwnerList()
        {
            Mock<FactoryContext> factoryContext = new Mock<FactoryContext>();

            List<Owner> owners = new List<Owner>()
            {
                new Owner(){Id=1},
                new Owner(){Id=2},
                new Owner(){Id=3},
            };

            factoryContext.Setup(fc => fc.Owners).ReturnsDbSet(owners);


            OwnerRepository ownerRepo = new OwnerRepository(factoryContext.Object);

            List<Owner> res = ownerRepo.GetAllOwners();
            Assert.Equal(3, res.Count);
        }
    }
}
