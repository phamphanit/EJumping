import { SliderData } from "../../../partials/Carousel/SliderData";
import Carousel from "./../../../partials/Carousel/Carousel";
import { useDispatch } from "react-redux";
import {
  fetchMyInfoSucceed,
  userLoginSucceed,
} from "./../../actions/userActions";
import { UserManager } from "oidc-client";
import oidcConfig from "./../Login/oidcConfig";

const HomePage = () => {
  const dispatch = useDispatch();
  const userManager = new UserManager(oidcConfig);
  const loadUser = async () => {
    const user = await userManager.getUser();
    if (user) {
      dispatch(userLoginSucceed(user));
      dispatch(fetchMyInfoSucceed(user.profile));
    }
    return user;
  };
  loadUser();

  return (
    <div>
      <Carousel slides={SliderData}></Carousel>
      <section
        style={{
          backgroundSize: "cover",
          backgroundPosition: "center",
        }}
        className="hero"
      >
        <div className="container">
          <div className="row">
            <div className="col-lg-7">
              <h1>Bootstrap 4 Blog - A free template by Bootstrap Temple</h1>
            </div>
          </div>
        </div>
      </section>
      <section className="intro">
        <div className="container">
          <div className="row">
            <div className="col-lg-8">
              <h2 className="h3">Some great intro here</h2>
              <p className="text-big">
                Place a nice <strong>introduction</strong> here{" "}
                <strong>to catch reader's attention</strong>. Lorem ipsum dolor
                sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                incididunt ut labore et dolore magna aliqua. Ut enim ad minim
                veniam, quis nostrud nisi ut aliquip ex ea commodo consequat.
                Duis aute irure dolor in reprehenderi.
              </p>
            </div>
          </div>
        </div>
      </section>
      <section className="featured-posts no-padding-top">
        <div className="container"></div>
      </section>
    </div>
  );
};
export default HomePage;
