using Business.Abstract;
using Business.Contstans;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DateAccess.Abstract;
using DateAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
       IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;            
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            if(CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                if(CheckIfProductNameExists(product.ProductName).Success)
                {
                    _ProductDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
                }
               

            }

            return new ErrorResult();
          
           

               

        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları

            if(DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }


            return new  SuccessDataResult<List<Product>>(_ProductDal.GetAll(),Messages.ProductsListed);
            
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _ProductDal.GetAll(p=>p.CategoryId==id));

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_ProductDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_ProductDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _ProductDal.GetAll(p => p.CategoryId == p.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _ProductDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();

        }


        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _ProductDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();

        }
    }
}
