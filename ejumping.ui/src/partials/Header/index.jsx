import "./Header.scss";
import { NavLink, Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { PageMenu } from "./../Menu/PageMenu";
const Header = () => {
  const dispatch = useDispatch();
  const isLoggedIn = useSelector((state) => state.user.isLoggedIn);
  const handleLogout = () => {};
  return (
    <header>
      <div className="top_bar">
        <div className="container">
          <div className="row">
            <div className="col d-flex flex-row">
              <div className="contact-item">
                <div className="icon">
                  <i class="far fa-mobile"></i>{" "}
                </div>
                <span>(+84) 919 262 894</span>
              </div>
              <div className="contact-item">
                <div className="icon">
                  <i class="fal fa-envelope"></i>{" "}
                </div>
                <span>ejumpingSale@gmail.com</span>
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
                          <i class="far fa-user mr-2"></i>
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
                  ) : (
                    <ul className="">
                      <li className="">
                        {" "}
                        <a className="">Hello</a>
                      </li>
                      <li className="">
                        <a onClick={handleLogout} className="">
                          Log out
                        </a>
                      </li>
                    </ul>
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
                  eJumping
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
                    <span class="custom_dropdown_placeholder clc">
                      All Categories
                    </span>
                    <i className="fas fa-chevron-down"></i>
                    <ul className="custom_list clc" style={{ display: "none" }}>
                      <li>
                        <a className="clc" href="#">
                          All Categories
                        </a>
                      </li>
                      <li>
                        <a className="clc" href="#">
                          Computers
                        </a>
                      </li>
                      <li>
                        <a className="clc" href="#">
                          Laptops
                        </a>
                      </li>
                      <li>
                        <a className="clc" href="#">
                          Cameras
                        </a>
                      </li>
                      <li>
                        <a className="clc" href="#">
                          Hardware
                        </a>
                      </li>
                      <li>
                        <a className="clc" href="#">
                          Smartphones
                        </a>
                      </li>
                    </ul>
                  </div>
                  <button>
                    <i class="fal fa-search text-white"></i>
                  </button>
                </form>
              </div>
            </div>
            <div className="cart_container col-lg-4 col-9 order-lg-3 order-2">
              <div className="right-item">
                <div className="icon">
                  <i class="fal fa-heart"></i>{" "}
                </div>
                <div className="content">
                  <span htmlFor="">Wishlist</span>
                  <span>115</span>
                </div>
              </div>
              <div className="right-item cart">
                <div className="icon">
                  <i class="fal fa-cart-plus"></i>
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
