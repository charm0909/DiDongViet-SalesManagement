using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ProductDAL
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        // Lấy tất cả sản phẩm
        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SanPham", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductDTO product = new ProductDTO
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            BrandID = reader["BrandID"] != DBNull.Value ? (int)reader["BrandID"] : 0,
                            CategoryID = reader["CategoryID"] != DBNull.Value ? (int)reader["CategoryID"] : 0,
                            ImportPrice = (decimal)reader["ImportPrice"],
                            SalePrice = (decimal)reader["SalePrice"],
                            QuantityInStock = (int)reader["QuantityInStock"],
                            Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : "",
                            Warranty = reader["Warranty"] != DBNull.Value ? reader["Warranty"].ToString() : "",
                            ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : ""
                        };
                        products.Add(product);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách sản phẩm: " + ex.Message);
            }
            return products;
        }

        // Lấy sản phẩm theo ID
        public ProductDTO GetProductByID(int productID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SanPham WHERE ProductID = @ProductID", conn);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ProductDTO product = new ProductDTO
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            BrandID = reader["BrandID"] != DBNull.Value ? (int)reader["BrandID"] : 0,
                            CategoryID = reader["CategoryID"] != DBNull.Value ? (int)reader["CategoryID"] : 0,
                            ImportPrice = (decimal)reader["ImportPrice"],
                            SalePrice = (decimal)reader["SalePrice"],
                            QuantityInStock = (int)reader["QuantityInStock"],
                            Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : "",
                            Warranty = reader["Warranty"] != DBNull.Value ? reader["Warranty"].ToString() : "",
                            ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : ""
                        };
                        reader.Close();
                        return product;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy sản phẩm: " + ex.Message);
            }
            return null;
        }

        // Thêm sản phẩm mới
        public bool AddProduct(ProductDTO product)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO SanPham (ProductName, BrandID, CategoryID, ImportPrice, SalePrice, QuantityInStock, Color, Warranty, ImagePath) VALUES (@ProductName, @BrandID, @CategoryID, @ImportPrice, @SalePrice, @QuantityInStock, @Color, @Warranty, @ImagePath)", conn);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@BrandID", product.BrandID);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    cmd.Parameters.AddWithValue("@ImportPrice", product.ImportPrice);
                    cmd.Parameters.AddWithValue("@SalePrice", product.SalePrice);
                    cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@Color", product.Color ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Warranty", product.Warranty ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }

        // Cập nhật sản phẩm
        public bool UpdateProduct(ProductDTO product)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE SanPham SET ProductName = @ProductName, BrandID = @BrandID, CategoryID = @CategoryID, ImportPrice = @ImportPrice, SalePrice = @SalePrice, QuantityInStock = @QuantityInStock, Color = @Color, Warranty = @Warranty, ImagePath = @ImagePath WHERE ProductID = @ProductID", conn);
                    cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@BrandID", product.BrandID);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    cmd.Parameters.AddWithValue("@ImportPrice", product.ImportPrice);
                    cmd.Parameters.AddWithValue("@SalePrice", product.SalePrice);
                    cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@Color", product.Color ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Warranty", product.Warranty ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật sản phẩm: " + ex.Message);
            }
        }

        // Xóa sản phẩm
        public bool DeleteProduct(int productID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM SanPham WHERE ProductID = @ProductID", conn);
                    cmd.Parameters.AddWithValue("@ProductID", productID);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa sản phẩm: " + ex.Message);
            }
        }

        // Tìm kiếm sản phẩm
        public List<ProductDTO> SearchProducts(string keyword)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SanPham WHERE ProductName LIKE @Keyword OR Color LIKE @Keyword", conn);
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductDTO product = new ProductDTO
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            BrandID = reader["BrandID"] != DBNull.Value ? (int)reader["BrandID"] : 0,
                            CategoryID = reader["CategoryID"] != DBNull.Value ? (int)reader["CategoryID"] : 0,
                            ImportPrice = (decimal)reader["ImportPrice"],
                            SalePrice = (decimal)reader["SalePrice"],
                            QuantityInStock = (int)reader["QuantityInStock"],
                            Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : "",
                            Warranty = reader["Warranty"] != DBNull.Value ? reader["Warranty"].ToString() : "",
                            ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : ""
                        };
                        products.Add(product);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm sản phẩm: " + ex.Message);
            }
            return products;
        }
    }
}
