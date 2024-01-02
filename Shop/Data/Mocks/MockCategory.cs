using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> Allcategories {
            get
            {
                return new List<Category>
                {
                    new Category {categoryName="Электромобили", categoryDescription="Современный вид транспорта"},
                    new Category {categoryName="Классические автомобили", categoryDescription="Машини с двигателем внутреннего згорания"},

                };
            }
        }
    }
}
