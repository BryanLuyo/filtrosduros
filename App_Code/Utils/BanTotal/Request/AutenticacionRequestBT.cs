namespace Utils.Bantotal.Request
{
    public class AutenticacionRequestBT : BaseRequest
    {
        private string _userId;

        private string _userPassword;

        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
            }
        }

        public AutenticacionRequestBT()
        {
        }

        public AutenticacionRequestBT(BtInreq btInReq, string userId, string userPassword)
            : base(btInReq)
        {
            _userId = userId;
            _userPassword = userPassword;
        }
    }

}


