using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OceanInstruments.ApiProxy;
using OceanInstruments.ApiProxy.Models;


namespace OceanInstruments.MockClient
{
    public partial class Form1 : Form
    {
    	
        private List<Model> Models;
        private List<Device> Devices;
        private List<Calibration> Calibrations;

        private OceanInstrumentsApiClient OIApiClient = null;

        public Form1()
        {
            InitializeComponent();

            OIApiClient = new OceanInstrumentsApiClient();

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
/*            var username = cboUsername.SelectedItem;
            var password = txtPassword.Text;

            if (username == null || String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter a username and password");
                return;
            }
*/
            try
            {
                await OIApiClient.Login();
                MessageBox.Show("Logged in as " + OIApiClient.LoggedInUser);

                RefreshModels();
                RefreshDevices();
                RefreshCalibrations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void RefreshModels()
        {
            try
            {
                Models = await OIApiClient.GetAsync<Model>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading models: " + ex.Message);
            }

            dgvModels.DataSource = null;
            dgvModels.DataSource = Models;
            modelBindingSource.DataSource = null;
            modelBindingSource.DataSource = Models;
        }

        private async void RefreshDevices()
        {
            try
            {
                Devices = await OIApiClient.GetAsync<Device>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading devices");
            }

            dgvDevices.DataSource = null;
            dgvDevices.DataSource = Devices;
            deviceBindingSource.DataSource = null;
            deviceBindingSource.DataSource = Devices;
        }

        private async void RefreshCalibrations()
        {
            try
            {
                Calibrations = await OIApiClient.GetAsync<Calibration>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading calibrations");
            }

            dgvCalibrations.DataSource = null;
            dgvCalibrations.DataSource = Calibrations;
        }

        private async void btnAddModel_Click(object sender, EventArgs e)
        {
            try
            {
                var model = new Model { Code = txtCode.Text, FullDesc = txtFullDesc.Text };
                model = await OIApiClient.PostAsync(model);

                Models.Add(model);
                dgvModels.DataSource = null;
                dgvModels.DataSource = Models;
                modelBindingSource.DataSource = null;
                modelBindingSource.DataSource = Models;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding model");
            }
        }

        private async void btnAddDevice_Click(object sender, EventArgs e)
        {
            try
            {
                Device device = new Device { SerialNo = txtSeialNo.Text, ModelId = ((Model)cboModels.SelectedValue).ModelId };
                device = await OIApiClient.PostAsync(device);

                Devices.Add(device);
                dgvDevices.DataSource = null;
                dgvDevices.DataSource = Devices;
                deviceBindingSource.DataSource = null;
                deviceBindingSource.DataSource = Devices;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding device");
            }
        }

        private async void btnAddCalibration_Click(object sender, EventArgs e)
        {
            try
            {
                Calibration calibration = new Calibration { DeviceId = ((Device)cboDevice.SelectedValue).ModelId, LowFreq = double.Parse(txtLow.Text), HighFreq = double.Parse(txtHigh.Text), Tone = double.Parse(txtTone.Text), RefLevel = double.Parse(txtRefLevel.Text) };
                calibration = await OIApiClient.PostAsync(calibration);

                Calibrations.Add(calibration);
                dgvCalibrations.DataSource = null;
                dgvCalibrations.DataSource = Calibrations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding calibration");
            }
        }

        private void btnGetModelData_Click(object sender, EventArgs e)
        {
            RefreshModels();
        }

        private void btnGetDeviceData_Click(object sender, EventArgs e)
        {
            RefreshDevices();
        }

        private void btnGetCalibrationData_Click(object sender, EventArgs e)
        {
            RefreshCalibrations();
        }

        private async void txtDeviceSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //would do client side, but just showing custom api call
                var searchValue = txtDeviceSearch.Text;

                if (searchValue.Length < 3)
                    RefreshDevices();
                else
                {
                    Devices = await OIApiClient.GetDevicesSearchAsync(searchValue);
                    dgvDevices.DataSource = null;
                    dgvDevices.DataSource = Devices;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error searching for device");
            }
        }

        private async void btnUpdateModels_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Model m in Models)
                    await OIApiClient.PutAsync(m.ModelId, m);
            }
            catch (Exception ex)
            {
                //Note: at present only admin users have update rights
                MessageBox.Show(ex.Message, "Error updating models");
            }

            RefreshModels();
        }

        private async void btnDeleteModel_Click(object sender, EventArgs e)
        {
            try
            {
                //the below is ugly no doubt, you would normally use a binding source, but just showing example of delete
                if (dgvModels.CurrentCell != null)
                {
                    int index = dgvModels.CurrentCell.RowIndex;
                    if (index < Models.Count)
                    {
                        Model m = Models[index];
                        await OIApiClient.DeleteAsync<Model>(m.ModelId);
                    }
                }
            }
            catch (Exception ex)
            {
                //Note: at present only admin users have delete rights
                MessageBox.Show(ex.Message, "Error deleting model");
            }

            RefreshModels();
        }
    }
}
