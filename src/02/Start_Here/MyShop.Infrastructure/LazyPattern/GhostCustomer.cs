using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.LazyPattern
{
    public class GhostCustomer : CustomerProxy
    {
        private readonly Func<Customer> _load;
        private LoadStatus status;

        public bool IsGhost => status == LoadStatus.GHOST;
        public bool IsLoaded => status == LoadStatus.LOADED;

        // The customer is now loaded when we access a property
        public override string Name
        {
            get
            {
                LoadCustomer();
                return base.Name;
            }
        
            set 
            {
                LoadCustomer();
                base.Name = value;
            }
        }

        public GhostCustomer(Func<Customer> load) : base()
        {
            _load = load;
            status = LoadStatus.GHOST;
        }

        private void LoadCustomer()
        {
            if (IsGhost)
            {
                status = LoadStatus.LOADING;
                var customer = _load();

                base.Name = customer.Name;
                base.ShippingAddress = customer.ShippingAddress;
                base.City = customer.City;
                base.Country = customer.Country;
                base.PostalCode = customer.PostalCode;
            }
            status = LoadStatus.LOADED;
        }
    }

    enum LoadStatus { GHOST = 0, LOADING = 1, LOADED =2};
}
