import "./Header.scss";
import { NavLink, Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
const Header = () => {
  const dispatch = useDispatch();
  const isLoggedIn = useSelector((state) => state.user.isLoggedIn);
  const handleLogout = () => {};
  return (
    <header>
      <nav className="navbar navbar-expand-sm navbar-light bg-light">
        <div className="left">
          <a className="navbar-brand">eJumping</a>
          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarNavDropdown"
            aria-controls="navbarNavDropdown"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNavDropdown">
            <ul className="navbar-nav">
              <li className="nav-item ">
                <Link to="/" className="nav-link">
                  Home
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/feature" className="nav-link">
                  Features
                </Link>
              </li>
              <li className="nav-item">
                <a className="nav-link">Pricing</a>
              </li>
              <li className="nav-item dropdown">
                <a
                  className="nav-link dropdown-toggle"
                  id="navbarDropdownMenuLink"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  Dropdown link
                </a>
                <div
                  className="dropdown-menu"
                  aria-labelledby="navbarDropdownMenuLink"
                >
                  <a className="dropdown-item">Action</a>
                  <a className="dropdown-item">Another action</a>
                  <a className="dropdown-item">Something else here</a>
                </div>
              </li>
            </ul>
          </div>
        </div>
        <div className="right">
          {!isLoggedIn ? (
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link to="/register" className="nav-link">
                  SignUp
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/login" className="nav-link">
                  SignIn
                </Link>
              </li>
            </ul>
          ) : (
            <ul className="navbar-nav">
              <li className="nav-item">
                {" "}
                <a className="nav-link">Hello</a>
              </li>
              <li className="nav-item">
                <a onClick={handleLogout} className="nav-link">
                  Log out
                </a>
              </li>
            </ul>
          )}
        </div>
      </nav>
    </header>
  );
};
export default Header;
