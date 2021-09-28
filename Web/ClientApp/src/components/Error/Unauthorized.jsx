import * as React from 'react';
import { connect } from 'react-redux';

class Unauthorized extends React.PureComponent {
    render() {
        return (
            <React.Fragment>
                <div className="s-content">
                    <div className="container-fluid">
                        <div className="card s-card s-card-mb shadow-sm">
                            <div className="card-header">
                                401 Unauthorized
                            </div>
                            <div className="card-body">
                                <h1>沒有使用權限，</h1>
                                <h2>請使用有權限的帳號!</h2>
                                <a href={'http://localhost/admin/login/Login.aspx?purl=' + window.location.origin + '/home'} className="btn s-btn-primary btn-lg"><span className="glyphicon glyphicon-home"></span>重新登入</a>
                                {/*<a href={'https://seos.sainteir.com/admin/login/Login.aspx?purl=' + window.location.origin + '/home'} className="btn s-btn-primary btn-lg"><span className="glyphicon glyphicon-home"></span>重新登入</a>*/}
                            </div>
                        </div>
                    </div>
                </div>
            </React.Fragment>
        );
    }
};

export default connect()(Unauthorized);
