using ClassLibrary.model;
using ClassLibrary.model.OcopModel;
using ClassLibrary.model.productModel;
using ClassLibrary.responsitory;

namespace VNPT.OCOPSERVICE.services.ocop
{
    public interface IProduct : IProductResponsetory<Products>
    {
        public dynamic getListProduct();
        public dynamic insertProduct(ProductsRequest productsRequest);
        public dynamic updateProduct(ProductsRequest productsRequest);
    }
}
