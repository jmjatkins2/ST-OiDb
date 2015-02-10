(function () {
    app.controller('calibrationsController', ['$http', function ($http) {
        var calibrationsCtrl = this;
        calibrationsCtrl.devices = {};
        calibrationsCtrl.selectedDevice;
        calibrationsCtrl.selectedCalibration;

        this.searchDevicesBySerialNo = function (serialNo) {
            calibrationsCtrl.selectedCalibration = null;

            return $http.get('../api/Devices/Search/' + serialNo).then(function (response) {
                var devices = response.data;

                //if exact match, select device
                if (devices.length == 1 && devices[0].serialNo == serialNo)
                {
                    calibrationsCtrl.selectDevice(devices[0]);
                    return devices;
                }
                else
                    return devices;
            });
        };

        this.onDeviceSelect = function ($item, $model, $label) {
            this.selectDevice($item);
        };

        this.selectDevice = function (device) {
            calibrationsCtrl.selectedDevice = device;
            this.getCalibrationsForSelectedDevice();
        }

        this.getCalibrationsForSelectedDevice = function () {
            $http.get('../api/Calibrations/Device/' + calibrationsCtrl.selectedDevice.deviceId).success(function (data) {
                calibrationsCtrl.selectedDevice.calibrations = data;

                //select latest calibration for initial display
                if (data.length >= 1)
                    calibrationsCtrl.selectedCalibration = calibrationsCtrl.selectedDevice.calibrations[0];
            });
        }

        this.onCalibrationSelect = function (calibration) {
            calibrationsCtrl.selectedCalibration = calibration;
        }

    }]);

})();