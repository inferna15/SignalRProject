using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountDal _discountDal;
        public DiscountService(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void Add(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void Delete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public List<Discount> GetAll()
        {
            return _discountDal.GetAll();
        }

        public Discount GetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public void Update(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
