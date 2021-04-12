import "./Footer.scss";
import { Link } from "react-router-dom";
const Footer = () => {
  return (
    <footer className="footer-wrapper">
      <div className="container row-footer__menu">
        <ul className="footer__menu">
          <li className="footer-tab__menu">
            <Link to="/privacy">Privacy</Link>
          </li>
          <span>/</span>
          <li className="footer-tab__menu">
            <Link to="/terms">Terms</Link>
          </li>
        </ul>
      </div>
      <div className="container row-footer__content">
        <div className="row">
          <div className="col-sm-12">
            <div className="footer-content">
              <div className="left">
                <Link to="/" className="logo">
                  <img src="/assets/images/logo.svg" />
                </Link>
                <div className="footer-info">
                  <p>Contact Number: 326-87-00373</p>
                  <p>Customer Service: help@.ejumping.com</p>
                  <p>
                    Copyright@<strong>EugenePhan.</strong>All rights reserved
                  </p>
                </div>
              </div>
              <div style={{ clear: "both" }}></div>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
};
export default Footer;
