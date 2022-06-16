using Northwind.Business.Abstract;
using Northwind.Business.ConCreate;
using Northwind.Business.DependencyResolvers.Ninject;
using Northwind.DataAcces.ConCreate.EntityFramework;
using Northwind.DataAcces.ConCreate.NHibernate;
using Northwind.Entities.ConCreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            //_productService = new ProductManager(new EfProductDal());
            //_categoryService = new CategoryManager(new EfCategoryDal());

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
        }
        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }
        private void LoadCategories()
        {
            cmbCategories.DataSource = _categoryService.GetAll();
            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "CategoryID";

            cmbCategoryAdd.DataSource = _categoryService.GetAll();
            cmbCategoryAdd.DisplayMember = "CategoryName";
            cmbCategoryAdd.ValueMember = "CategoryID";

            cmbUptCategory.DataSource = _categoryService.GetAll();
            cmbUptCategory.DisplayMember = "CategoryName";
            cmbUptCategory.ValueMember = "CategoryID";

        }
        private void CmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductByCategoryID(Convert.ToInt32(cmbCategories.SelectedValue));
            }
            catch
            {

            }

        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                dgwProduct.DataSource = _productService.GetBySearcText(txtSearch.Text.ToLower());
            }
            else
            {
                LoadProducts();

            }
            
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                _productService.Add(new Product
                {
                ProductName = txtProductName.Text,
                QuantityPerUnit=txtQuantity.Text,
                UnitPrice=Convert.ToDecimal(txtPrice.Text),
                UnitsInStock=Convert.ToInt16(txtStock.Text),
                CategoryID=Convert.ToInt32(cmbCategoryAdd.SelectedValue)
                 });
                MessageBox.Show("Ürün eklendi!");
                LoadProducts();//eklendikten sonra yüklesin tekrardan.
            }
            catch(Exception exception) 
            {
                MessageBox.Show(exception.Message);
            }
            
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {
                    ProductID=Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    ProductName = txtUptName.Text,
                    QuantityPerUnit =txtUptQuantity.Text,
                    UnitPrice = Convert.ToDecimal(txtUptPrice.Text),
                    UnitsInStock = Convert.ToInt16(txtUptStock.Text),
                    CategoryID = Convert.ToInt32(cmbUptCategory.SelectedValue)
                });
                MessageBox.Show("Ürün Güncellendi!");
                LoadProducts();//eklendikten sonra yüklesin tekrardan.

            }

            
            catch 
            {

                
            }
        }        
        private void DgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUptName.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            txtUptPrice.Text= dgwProduct.CurrentRow.Cells[4].Value.ToString();
            txtUptQuantity.Text= dgwProduct.CurrentRow.Cells[3].Value.ToString();
            txtUptStock.Text= dgwProduct.CurrentRow.Cells[5].Value.ToString();
            cmbUptCategory.SelectedValue= dgwProduct.CurrentRow.Cells[2].Value;

        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
                _productService.Delete(new Product { ProductID = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)});
            }

            LoadProducts();
        }
            
    }
}
