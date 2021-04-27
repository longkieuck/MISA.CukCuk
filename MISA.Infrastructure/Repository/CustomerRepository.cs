using MISA.Infrastructure.Interface;
using MISA.Infrastructure.Model;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public bool CheckCustomerCodeExist(string customerCode)
        {
            return true;
        }

        public bool CheckPhoneNumberExist(string customerCode)
        {
            return true;
        }
    }
}
