import * as React from 'react';
import { connect } from 'react-redux';
import * as store from '../Shortemer/ShortenUrl.js';
import LoadingOverlay from 'react-loading-overlay';

import '../../css/shortemerform.css';

class ShortenUrl extends React.PureComponent {
    render() {
        return (
            <React.Fragment>
                <LoadingOverlay
                    active={this.props.value.isActive}
                    spinner
                    text='Loading...'
                >
                    <div className="text-center">
                        <main className="form-signin">
                            <form>
                                <div className="p-3 mb-4 bg-light rounded-3">
                                    <div className="container-fluid py-5">
                                        {/*<h1 className="display-5 fw-bold">Short links, bigger result</h1>*/}
                                        <h1 className="display-5 fw-bold">就。很。Short</h1>
                                        <p className="col-md-12 fs-4">讓連結更加簡短、且便於分享。</p>
                                        <div className="form-floating mt-3">
                                            <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com"
                                                onChange={(e) => { this.props.setUrl(e.target.value); }} />
                                            <label htmlFor="floatingInput">在這裡輸入你的網址:</label>
                                        </div>
                                        <button className="w-100 btn btn-lg btn-primary mb-3 mt-3" type="button" onClick={() => { this.props.post(); }}>產生</button>
                                    </div>
                                </div>
                                <p className="mt-5 mb-3 text-muted">© 2017–2021</p>
                                <p className="mt-5 mb-3 text-muted">我們的目標是提供可靠的服務，讓我們的客戶集中精力處理最重要的事務。</p>
                                <p className="mt-5 mb-3 text-muted">{this.props.value.translationUrl}</p>
                            </form>
                        </main>
                    </div>
                </LoadingOverlay >
            </React.Fragment>
        );
    }
};

export default connect((state) => state.shortemer, store.actionCreators)(ShortenUrl);
