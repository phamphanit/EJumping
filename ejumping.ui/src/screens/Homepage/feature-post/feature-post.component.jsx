const FeaturePost = ({ reverse }) => {
  return (
    <div
      className="row d-flex align-items-stretch"
      style={reverse ? { flexDirection: "row-reverse" } : null}
    >
      <div className="image col-lg-5" alt="logo" style={{ minHeight: "392px" }}>
        {/* <img src={image} /> */}
      </div>
      <div className="text col-lg-7">
        <div className="text-inner d-flex align-items-center">
          <div className="content">
            <header className="post-header">
              <div className="category">
                <a href="#">Business</a>
                <a href="#">Technology</a>
              </div>
              <a href="post.html">
                <h2 className="h4">
                  Alberto Savoia Can Teach You About Interior
                </h2>
              </a>
            </header>
            <p>
              Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do
              eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut
              enim ad minim veniam, quis nostrude consectetur adipisicing elit,
              sed do eiusmod tempor incididunt.
            </p>
            <footer className="post-footer d-flex align-items-center">
              <div
                href="#"
                className="author d-flex align-items-center flex-wrap"
              >
                <div className="avatar">
                  <img src="img/avatar-2.jpg" alt="..." className="img-fluid" />
                </div>
                <div className="title">
                  <span>John Doe</span>
                </div>
              </div>
              <div className="date">
                <i className="icon-clock"></i> 2 months ago
              </div>
              <div className="comments">
                <i className="icon-comment"></i>12
              </div>
            </footer>
          </div>
        </div>
      </div>
    </div>
  );
};
export default FeaturePost;
