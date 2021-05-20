import "./Header.scss";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { userLogoutRequest } from "../../components/actions/userActions";
import "antd/dist/antd.css";
import { UserManager } from "oidc-client";
import oidcConfig from "../../components/pages/Login/oidcConfig";
const Header = () => {
  const dispatch = useDispatch();
  const isLoggedIn = useSelector((state) => state.user.isLoggedIn);
  const userInfo = useSelector((state) => state.user.myInfo);
  const handleLogout = () => {
    const userManager = new UserManager(oidcConfig);
    const loadUser = async () => {
      const user = await userManager.getUser();
      if (user) {
        userManager.signoutRedirect();
      }
    };
    loadUser();
    dispatch(userLogoutRequest());
  };
  return (
    <header>
      <div className="top_bar">
        <div className="container">
          <div className="row">
            <div className="col d-flex flex-row">
              {/* <div className="contact-item">
                <div className="icon">
                  <i class="far fa-mobile"></i>{" "}
                </div>
                <span>(+84) 919 262 894</span>
              </div> */}
              <div className="contact-item">
                <div className="icon">
                  <i className="fal fa-envelope"></i>{" "}
                </div>
                <span>CaliSpeak@gmail.com</span>
              </div>
              <div className="content-items ml-auto d-flex">
                <ul className="item-stuff">
                  <li>English</li>
                  <li>$ US dollar</li>
                </ul>
                <div className="item-user ">
                  {!isLoggedIn ? (
                    <ul className="d-flex flex-row">
                      <li className="">
                        <span className="icon">
                          <i className="far fa-user mr-2"></i>
                        </span>
                        <Link to="/register" className="register">
                          Sign Up
                        </Link>
                      </li>
                      <li className="">
                        <Link to="/login" className="login">
                          Sign In
                        </Link>
                      </li>
                    </ul>
                  ) : userInfo ? (
                    <ul className="d-flex flex-row">
                      <li className="user-info">
                        <img
                          src={`${userInfo.profileImageUrl}`}
                          alt=""
                          className="mr-1"
                        />
                        <span>{userInfo.userName}</span>
                      </li>
                      <li className="">
                        <Link onClick={handleLogout} className="" to="/logout">
                          Log out
                        </Link>
                      </li>
                    </ul>
                  ) : (
                    ""
                  )}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="header_main">
        <div className="container">
          <div className="row">
            <div className="logo-container col-lg-2 col-3  order-1">
              <div className="header_logo ">
                <img src="" alt="" />
                <Link to="/" className="logo">
                  Cali Speak
                </Link>
              </div>
            </div>
            <div className="header_search_container col-lg-6 col-12 order-lg-2 order-3">
              <div className="header_search_form">
                <form action="">
                  <input
                    type="text"
                    className="header_search_input"
                    placeholder="Search for Product ..."
                  />
                  <div className="search_list_category">
                    <span className="custom_dropdown_placeholder clc">
                      All Categories
                    </span>
                    <i className="fas fa-chevron-down"></i>
                    <ul className="custom_list clc" style={{ display: "none" }}>
                      <li>
                        <Link to="/" className="clc">
                          All Categories
                        </Link>
                      </li>
                      <li>
                        <Link to="/" className="clc">
                          Computers
                        </Link>
                      </li>
                      <li>
                        <Link to="/" className="clc">
                          Laptops
                        </Link>
                      </li>
                      <li>
                        <Link to="/" className="clc">
                          Cameras
                        </Link>
                      </li>
                      <li>
                        <Link to="/" className="clc">
                          Hardware
                        </Link>
                      </li>
                      <li>
                        <Link to="/" className="clc">
                          Smartphones
                        </Link>
                      </li>
                    </ul>
                  </div>
                  <button>
                    <i className="fal fa-search text-white"></i>
                  </button>
                </form>
              </div>
            </div>
            <div className="cart_container col-lg-4 col-9 order-lg-3 order-2">
              <div className="right-item">
                <div className="icon">
                  <i className="fal fa-heart"></i>{" "}
                </div>
                <div className="content">
                  <span htmlFor="">Wishlist</span>
                  <span>115</span>
                </div>
              </div>
              <div className="right-item cart">
                <div className="icon">
                  <i className="fal fa-cart-plus"></i>
                </div>
                <div className="cart-count">
                  <span>5</span>
                </div>
                <div className="content">
                  <span htmlFor="">Cart</span>
                  <span>$6</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </header>
  );
};
export default Header;
