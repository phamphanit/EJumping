import { NavLink, Link } from 'react-router-dom';
const Header = () => {
  return (
    <header className="header">
      <nav className="navbar navbar-expand-lg">
        <div className="container">
          <div className="navbar-header d-flex align-items-center justify-content-between">
            <Link to="/" className="navbar-brand">Bootstrap Blog</Link>

            <button type="button" data-toggle="collapse" data-target="#navbarcollapse" aria-controls="navbarcollapse" aria-expanded="false" aria-label="Toggle navigation" className="navbar-toggler"><span></span><span></span><span></span></button>
          </div>

          <div id="navbarcollapse" className="collapse navbar-collapse">
            <ul className="navbar-nav ml-auto">
              <li className="nav-item"><NavLink to='/' exact className="nav-link ">Home</NavLink>
              </li>
              <li className="nav-item"><NavLink to='/blog' className="nav-link ">Blog</NavLink>
              </li>
              <li className="nav-item"><NavLink to="/post" className="nav-link ">Post</NavLink>
              </li>
              <li className="nav-item"><NavLink to="/contact" className="nav-link ">Contact</NavLink>
              </li>
            </ul>
            <div className="navbar-text"><a href="#" className="search-btn"><i className="icon-search-1"></i></a></div>
            <ul className="langs navbar-text"><a href="#" className="active">EN</a><span>           </span><a href="#">ES</a></ul>
          </div>
        </div>
      </nav>
    </header>
  );
}
export default Header;