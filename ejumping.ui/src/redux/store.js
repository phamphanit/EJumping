import { createStore, applyMiddleware } from 'redux';
import { createBrowserHistory } from 'history';
import { routerMiddleware } from 'connected-react-router'

import createSagaMiddleware from 'redux-saga';
import { composeWithDevTools } from 'redux-devtools-extension';
import rootSaga from './sagas';
import rootReducer from './reducers'
const sagaMiddleware = createSagaMiddleware();
export const history = createBrowserHistory();
const routerMiddlewaree = routerMiddleware(history);
const middlewares = [sagaMiddleware, routerMiddlewaree];
export const store = createStore(rootReducer(history), composeWithDevTools(applyMiddleware(...middlewares)));

sagaMiddleware.run(rootSaga);