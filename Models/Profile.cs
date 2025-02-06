namespace eSimAPI.Models {
    public partial class Profile
    {
        public string ICCID { get; set; }
        public string IMSI { get; set; }
        public string ActivationCode { get; set; }
        public string Status { get; set; }

        public Profile() {
            if (ICCID == null) {
                ICCID = "";
            }

            if (IMSI == null) {
                IMSI = "";
            }

            if (ActivationCode == null) {
                ActivationCode = "";
            }

            if (Status == null) {
                Status = "";
            }
        }
    }
}