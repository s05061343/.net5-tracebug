import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { getApiUserLoginCheck } from '../utils/api.js';

class AuthorizedRouteCookie extends React.Component {
    render() {
        console.log(this.props);

        const { component: Component, pending, user, ...rest } = this.props

        const isAuth = sessionStorage.getItem("authToken");

        if (!isAuth) {
            getApiUserLoginCheck()
                .then(res => {
                    console.log(res);
                    if (res.status === 200) {
                        sessionStorage.setItem("authToken", JSON.parse(res.request.response).token);
                        this.setState({});
                    }
                })
                .catch(err => {
                    sessionStorage.removeItem("authToken");
                })
        }

        if (isAuth && this.props.location.pathname === "/unauthorized") {
            console.log("isAuth unauthorized");
            return (
                <Redirect to="/home" />
            )
        }

        return (
            <Route {...rest} render={props => {
                return isAuth || this.props.location.pathname === "/unauthorized" ?
                    <Component {...props} /> : <Redirect to="/unauthorized" />
            }} />
        )
    }
}

export default connect((state) => state.loginUser)(AuthorizedRouteCookie);