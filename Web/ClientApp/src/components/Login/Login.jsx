import * as React from 'react';
import { connect } from 'react-redux';
import * as store from '../Login/Login.js';

import '../../css/signin.css';

class Login extends React.PureComponent {
    render() {
        return (
            <React.Fragment>
                <div className="text-center">
                    <main className="form-signin">
                        <form>
                            <img className="mb-4" src="https://getbootstrap.com/docs/5.0/assets/brand/bootstrap-logo.svg" alt="" width="72" height="57" />
                            <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
                            <div className="form-floating">
                                <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com"
                                    onChange={(e) => { this.props.setUserId(e.target.value); }} />
                                <label htmlFor="floatingInput">Email address</label>
                            </div>
                            <div className="form-floating">
                                <input type="password" className="form-control" id="floatingPassword" placeholder="Password"
                                    onChange={(e) => { this.props.setPassword(e.target.value); }} />
                                <label htmlFor="floatingPassword">Password</label>
                            </div>
                            <div className="checkbox mb-3">
                                <label>
                                    <input type="checkbox" value="remember-me" /> Remember me
                                </label>
                            </div>
                            <button className="w-100 btn btn-lg btn-primary" type="button" onClick={() => { this.props.post(); }}>Sign in</button>
                            <p className="mt-5 mb-3 text-muted">© 2017–2021</p>
                        </form>
                    </main>
                </div>
            </React.Fragment>
        );
    }
};

export default connect((state) => state.loginUser, store.actionCreators)(Login);
