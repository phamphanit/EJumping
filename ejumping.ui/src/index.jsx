import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { Provider } from "react-redux";
import { persistor, store } from "./redux/store";
import { history } from "./redux/store";
import { ConnectedRouter } from "connected-react-router";
// import 'bootstrap/dist/css/bootstrap.min.css';
import "./_scss/style.scss";
import { PersistGate } from "redux-persist/integration/react";
// or 'antd/dist/antd.less'

ReactDOM.render(
  <Provider store={store}>
    <PersistGate persistor={persistor}>
      <ConnectedRouter history={history}>
        <React.StrictMode>
          <App />
        </React.StrictMode>
      </ConnectedRouter>
    </PersistGate>
  </Provider>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
