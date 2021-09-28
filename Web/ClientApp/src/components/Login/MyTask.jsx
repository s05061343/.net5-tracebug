import * as React from 'react';
import { connect } from 'react-redux';
import * as store from '../Login/Login.js';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class MyTask extends React.PureComponent {
    state = {
        isOpen: false
    };

    render() {
        return (
            <React.Fragment>
                <div className="container-fluid mt-4">
                    <div className="card s-card s-card-mb shadow-sm" style={{ visibility: this.props.user.roleNo == 2 ? 'hidden' : 'visible' }}>
                        <button type="button" className="btn btn-primary btn-lg" onClick={this.toggle}>新增表單</button>
                    </div>
                    <div className="card s-card s-card-mb shadow-sm">
                        <div className="card-header">
                            <div className="d-flex justify-content-between">
                                <div>
                                    職稱 : ({this.props.user.role})
                                </div>
                                <div>
                                    <button type="button" className="btn btn-primary" onClick={() => { this.props.logout(); }}>切換使用者</button>
                                </div>
                            </div>
                        </div>
                        <div className="card-body">
                            姓名 : {this.props.user.name}
                        </div>
                    </div>
                    <div className="card s-card s-card-mb shadow-sm">
                        <div className="card-header">
                            <div className="d-flex justify-content-between">
                                <div>
                                    <h1 className="fw-bold">我的任務</h1>
                                </div>

                            </div>
                        </div>
                        <div className="card-body">
                            <table className="table s-table table-bordered">
                                <thead>
                                    <tr>
                                        <th scope="col">名稱</th>
                                        <th scope="col">進度</th>
                                        <th scope="col">所屬</th>
                                        <th scope="col">內容</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>TD</td>
                                        <td>TD</td>
                                        <td>TD</td>
                                        <td>TD</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <Modal isOpen={this.state.isOpen} toggle={this.toggle}>
                    <ModalHeader toggle={this.toggle}>新增表單</ModalHeader>
                    <ModalBody>
                        <form>
                            <div className="form-floating mb-3">
                                任務名稱 :
                                <input type="text" className="form-control" onChange={(e) => { this.props.addformTitle(e.target.value); }} />
                            </div>
                            <div className="form-floating mb-3">
                                負責人員 :
                                <select className="form-select" style={{ fontSize: '20px' }} aria-label="Default select example" onChange={(e) => { this.props.addformUser(e.target.value); }}>
                                    <option value="ts001">王曉明</option>
                                    <option value="ts002">劉俊麟</option>
                                    <option value="ts003">金城武</option>
                                </select>
                            </div>
                            <div className="form-floating mb-3">
                                任務說明 :
                                <textarea className="form-control" aria-label="With textarea" placeholder="請輸入..." onChange={(e) => { this.props.addformDescription(e.target.value); }}></textarea>
                            </div>
                        </form>
                    </ModalBody>
                    <ModalFooter>
                        <Button color="primary" onClick={this.toggle}>送出</Button>{' '}
                        <Button color="secondary" onClick={this.toggle}>取消</Button>
                    </ModalFooter>
                </Modal>
            </React.Fragment>
        );
    }

    toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
};

export default connect((state) => state.loginUser, store.actionCreators)(MyTask);
