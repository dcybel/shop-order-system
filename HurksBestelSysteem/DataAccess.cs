﻿using System;
using HurksBestelSysteem.Domain;
using HurksBestelSysteem.DAO;
using HurksBestelSysteem.Database;

namespace HurksBestelSysteem
{
    public class DataAccess
    {
        private static DAOFactory daoFactory;

        public DataAccess()
        {
            if (daoFactory == null)
            {
                daoFactory = DAOFactory.GetDAOFactory(DAOFactory.FactoryType.MySQL);
            }
        }

        //#################### PRODUCT FUNCTIONS ###########################
        //#################### PRODUCT FUNCTIONS ###########################
        #region PRODUCT_FUNCTIONS

        //returnt false als de gegevens niet kloppen
        //returnt true als de gegevens wel kloppen en de klant is toegevoegd
        public bool AddProduct(Product product)
        {
            ProductDAO dao = daoFactory.GetProductDAO();
            try
            {
                return dao.AddProduct(product);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetProductByCode(int productCode, out Product product)
        {
            ProductDAO dao = daoFactory.GetProductDAO();
            try
            {
                return dao.GetProductByCode(productCode, out product);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetProductsByName(string productName, out Product[] products)
        {
            ProductDAO dao = daoFactory.GetProductDAO();
            try
            {
                return dao.GetProductsByName(productName, out products);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveProduct(Product p)
        {
            ProductDAO dao = daoFactory.GetProductDAO();
            try
            {
                return dao.RemoveProduct(p);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetProductsByCategory(ProductCategory[] categories, out Product[] products)
        {
            ProductDAO dao = daoFactory.GetProductDAO();
            try
            {
                return dao.GetProductsByCategory(categories, out products);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion PRODUCT_FUNCTIONS
        //#################### END OF PRODUCT FUNCTIONS ####################
        //#################### END OF PRODUCT FUNCTIONS ####################

        //#################### CATEGORY FUNCTIONS ##########################
        //#################### CATEGORY FUNCTIONS ##########################
        #region CATEGORY_FUNCTIONS

        public bool GetProductCategories(out ProductCategory[] categories)
        {
            CategoryDAO dao = daoFactory.GetCategoryDAO();
            try
            {
                return dao.GetAllCategories(out categories);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCategory(ProductCategory category)
        {
            CategoryDAO dao = daoFactory.GetCategoryDAO();
            try
            {
                return dao.AddCategory(category);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveCategory(ProductCategory category)
        {
            CategoryDAO dao = daoFactory.GetCategoryDAO();
            try
            {
                return dao.RemoveCategory(category);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion CATEGORY_FUNCTIONS
        //#################### END OF CATEGORY FUNCTIONS ###################
        //#################### END OF CATEGORY FUNCTIONS ###################

        //###################### ORDER FUNCTIONS ###########################
        //###################### ORDER FUNCTIONS ###########################
        #region ORDER_FUNCTIONS

        public bool AddOrder(Order order)
        {
            OrderDAO dao = daoFactory.GetOrderDAO();
            try
            {
                return dao.AddOrder(order);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveOrder(Order order)
        {
            OrderDAO dao = daoFactory.GetOrderDAO();
            try
            {
                return dao.RemoveOrder(order);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetAllOrders(out Order[] orders)
        {
            OrderDAO dao = daoFactory.GetOrderDAO();
            try
            {
                Order[] allOrders;
                if (dao.GetAllOrders(out allOrders))
                {
                    CustomerDAO daoCustomer = daoFactory.GetCustomerDAO();
                    Customer skeletonCustomer;
                    Customer completeCustomer;
                    Order order;
                    for (int i = 0; i < allOrders.Length; i++)
                    {
                        order = allOrders[i];
                        skeletonCustomer = order.customer;
                        if (daoCustomer.GetCustomerByID(skeletonCustomer.internalID, out completeCustomer) == false)
                        {
                            throw new Exception("Could not retrieve customer with id " + skeletonCustomer.internalID + " for order " + order.internalID + " from " + skeletonCustomer.lastName);
                        }
                        else
                        {
                            order.customer = completeCustomer;
                        }
                    }
                    orders = allOrders;
                    return true;
                }
                else
                {
                    orders = new Order[0];
                    return false;
                }
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetOrdersByCustomer(Customer customer, out Order[] orders)
        {
            OrderDAO dao = daoFactory.GetOrderDAO();
            try
            {
                return dao.GetOrdersByCustomer(customer, out orders);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetOrdersByPickupDate(DateTime date, out Order[] orders)
        {
            OrderDAO dao = daoFactory.GetOrderDAO();
            try
            {
                return dao.GetOrdersByPickupDate(date, out orders);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetOrdersByOrderedDate(DateTime date, out Order[] orders)
        {
            OrderDAO dao = daoFactory.GetOrderDAO();
            try
            {
                return dao.GetOrdersByOrderedDate(date, out orders);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetOrdersByEmployee(Employee employee, out Order[] orders)
        {
            OrderDAO dao = daoFactory.GetOrderDAO();
            try
            {
                return dao.GetOrdersByEmployee(employee, out orders);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion ORDER_FUNCTIONS
        //###################### END OF ORDER FUNCTIONS ####################
        //###################### END OF ORDER FUNCTIONS ####################

        //##################### CUSTOMER FUNCTIONS #########################
        //##################### CUSTOMER FUNCTIONS #########################
        #region CUSTOMER_FUNCTIONS

        public bool AddCustomer(Customer customer)
        {
            CustomerDAO dao = daoFactory.GetCustomerDAO();
            try
            {
                return dao.AddCustomer(customer);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetCustomersByName(string customerName, out Customer[] customers)
        {
            CustomerDAO dao = daoFactory.GetCustomerDAO();
            try
            {
                return dao.GetCustomersByName(customerName, out customers);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetAllCustomers(out Customer[] customers)
        {
            CustomerDAO dao = daoFactory.GetCustomerDAO();
            try
            {
                return dao.GetAllCustomers(out customers);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion CUSTOMER_FUNCTIONS
        //##################### END OF CUSTOMER FUNCTIONS ##################
        //##################### END OF CUSTOMER FUNCTIONS ##################

    }
}
