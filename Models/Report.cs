using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CERTIFYWebHookAPI.Models
{
    public class Report
    {
        public string memberId { get; set; }
        public string accessId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string temperature { get; set; }
        public string temperatureFormat { get; set; }
        public bool exceedThreshold { get; set; }
        public DateTime temperatureRecordTime { get; set; }
        public DateTime? deviceTime { get; set; }
        public string deviceId { get; set; }
        public string deviceName { get; set; }
        public string sourceIP { get; set; }
        public string uid { get; set; }
        public string qrCodeId { get; set; }
        public int? trqStatus { get; set; }
        public string trigger { get; set; }
        public int? maskStatus { get; set; }
        public int? faceScore { get; set; }
        public string facilityName { get; set; }
        public string locationName { get; set; }
        public object deviceParameters { get; set; }
        public DeviceData deviceData { get; set; }
    }
    public class DeviceData
    {
        public string osVersion { get; set; }
        public string appVersion { get; set; }
        public string mobileIp { get; set; }
        public string mobileNumber { get; set; }
        public string uniqueDeviceId { get; set; }
        public string IMEINumber { get; set; }
        public string deviceModel { get; set; }
        public string deviceSN { get; set; }
        public string batteryStatus { get; set; }
        public string networkStatus { get; set; }
        public string sourceIP { get; set; }
    }
}