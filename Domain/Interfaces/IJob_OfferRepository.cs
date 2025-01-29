
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IJob_OfferRepository
    {
        Job_Offer GetById(int JobOfferId);
        void Add(Job_Offer JobOffer);
        void Update(Job_Offer JobOffer);
        void Delete(int JobOfferId);








    }
}
