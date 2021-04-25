import { createStore, applyMiddleware } from 'redux';
import { createBrowserHistory } from 'history';
import { routerMiddleware } from 'connected-react-router'
import { persistStore, persistReducer } from 'redux-persist'

import createSagaMiddleware from 'redux-saga';
import { composeWithDevTools } from 'redux-devtools-extension';
import rootSaga from './sagas';
import rootReducer from './reducers';
import storage from 'redux-persist/lib/storage';
const sagaMiddleware = createSagaMiddleware();
export const history = createBrowserHistory();
const routerMiddlewaree = routerMiddleware(history);

const middlewares = [sagaMiddleware, routerMiddlewaree];

const persistConfig = {
        key: "root",
        storage,
        whitelist: ["user"],
};

const persistedReducer = persistReducer(persistConfig, rootReducer(history))
export const store = createStore(
        persistedReducer,
        composeWithDevTools(applyMiddleware(...middlewares
        )));

sagaMiddleware.run(rootSaga);

export const persistor = persistStore(store);