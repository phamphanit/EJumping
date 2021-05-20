import "./Footer.scss";
const Footer = () => {
  return (
    <footer>
      <div className="container footer_content">
        <div className="row">
          <div className="col-lg-4">
            <div className="contact">
              <div className="logo_container">
                <div className="logo">CaliSpeak</div>
                <div>Got Question? Call Us 24/7</div>
                <div>ETown Cong Hoa, Viet Nam</div>
                <div className="footer_social">
                  {/* <ul>
                    <li>
                      <Link>
                        <i className="fab fa-facebook-f"></i>
                      </Link>
                    </li>
                    <li>
                      <Link>
                        <i className="fab fa-twitter"></i>
                      </Link>
                    </li>
                    <li>
                      <Link>
                        <i className="fab fa-youtube"></i>
                      </Link>
                    </li>
                    <li>
                      <Link>
                        <i className="fab fa-google"></i>
                      </Link>
                    </li>
                    <li>
                      <Link>
                        <i className="fab fa-vimeo-v"></i>
                      </Link>
                    </li>
                  </ul> */}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="footer_bot">
        <div className="container">
          <div className="row">
            <div>Copyright ©2021 All rights reserved | Eugene Pham</div>
          </div>
        </div>
      </div>
    </footer>
  );
};
export default Footer;
