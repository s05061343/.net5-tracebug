import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
class AuthorizedRoute extends React.Component {
    render() {
        const { component: Component, pending, user, ...rest } = this.props

        const isAuth = sessionStorage.getItem("authToken");
        
        if (isAuth && this.props.location.pathname === '/login') {
            return (
                <Redirect to="/logout" />
            )
        }

        return (
            <Route {...rest} render={props => {
                return isAuth || this.props.location.pathname === '/login'
                    ? <Component {...props} />
                    : <Redirect to="/login" />
            }} />
        )
    }
}

export default connect((state) => state.loginUser)(AuthorizedRoute);