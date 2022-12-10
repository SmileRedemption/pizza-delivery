using Model;
using View;

namespace Presenter
{
    public class CustomerPresenter : IPresenter
    {
        private readonly Customer _customer;
        private readonly CustomerView _customerView;

        public CustomerPresenter(Customer customer, CustomerView customerView)
        {
            _customer = customer;
            _customerView = customerView;
        }

        public void Enable()
        {
            _customerView.CollidedWithBike += OnCollidedWithBike;
            _customer.PizzaAdded += OnPizzaAdded;
        }

        public void Disable()
        {
            _customerView.CollidedWithBike -= OnCollidedWithBike;
            _customer.PizzaAdded -= OnPizzaAdded;
        }
        
        private void OnCollidedWithBike()
        {
            _customer.SetPizza(new Pizza());
        }
        
        private void OnPizzaAdded()
        {
            _customerView.OnPizzaAdded();
        }
    }
}