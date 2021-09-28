import * as React from 'react';
import { connect } from 'react-redux';
import * as store from '../Login/Login.js';

class Logout extends React.PureComponent {
    render() {
        return (
            <React.Fragment>
                <div className="container">
                    <div className="row">
                        <div className="col-md-5 mx-auto">
                            <div id="first">
                                <div className="myform form ">
                                    <form action="" method="post" name="login">
                                        <div className="d-grid gap-2">
                                            <button type="button" className="btn btn-success btn-lg" onClick={() => { this.props.logout(); }}>登出</button>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </React.Fragment>
        );
    }
};

export default connect((state) => state.loginUser, store.actionCreators)(Logout);
