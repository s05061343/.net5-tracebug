import React from 'react'
import { BrowserRouter, Switch } from 'react-router-dom'
import { Redirect, Route } from 'react-router-dom'
/*import AuthorizedRoute from './store/AuthorizedRoute.js'*/
import ReactNotification from 'react-notifications-component'
/*import AuthorizedRouteCookie from './store/AuthorizedRouteCookie.js'*/
/*import { HashRouter } from "react-router-dom";*/

// Layouts
import Layout from './components/Layout.jsx';
//import Home from './components/Home/Home.jsx';
//import Login from './components/Login/Login.jsx';
//import Logout from './components/Login/Logout.jsx';
//import NotFound from './components/Error/NotFound.jsx';
//import Unauthorized from './components/Error/Unauthorized.jsx';
import ShortenUrl from './components/Shortemer/ShortenUrl.jsx';

import '../src/css/custom.css'
import 'react-notifications-component/dist/theme.css'

export default () => (
    <div>
        <ReactNotification />
        <BrowserRouter>
            <Layout>
                <Switch>
                    {/*<AuthorizedRoute exact path="/home" component={Home} />*/}
                    {/*<AuthorizedRoute path="/logout" component={Logout} />*/}
                    {/*<AuthorizedRoute path="/login" component={Login} />*/}
                    {/*<Route path="/not_found" component={NotFound} />*/}
                    {/*<AuthorizedRoute path="/unauthorized" component={Unauthorized} />*/}
                    <Route path="/shortenurl" component={ShortenUrl} />
                    <Redirect to="/shortenurl" />
                </Switch>
            </Layout>
        </BrowserRouter>
    </div>
);