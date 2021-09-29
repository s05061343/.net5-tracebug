import * as React from 'react';
import { connect } from 'react-redux';
import * as store from '../Login/Login.js';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class MyTask extends React.PureComponent {
    state = {
        isOpen: false,
        belong: this.props.postFormQuery()
    };

    render() {
        return (
            <React.Fragment>
                <div className="container-fluid mt-4">
                    <div className="card s-card s-card-mb shadow-sm">
                        <div className="card-header">
                            <div className="d-flex justify-content-between">
                                <div>
                                    職稱 : ({this.props.loginUser.user.role})
                                </div>
                                <div>
                                    <button type="button" className="btn btn-primary" onClick={() => { this.props.logout(); }}>切換使用者</button>
                                </div>
                            </div>
                        </div>
                        <div className="card-body">
                            姓名 : {this.props.loginUser.user.name}
                        </div>
                    </div>
                    <div className="card s-card s-card-mb shadow-sm mt-4" style={{ display: this.props.loginUser.user.roleNo === 2 ? 'none' : '' }}>
                        <div className="card-header">
                            <div className="d-flex justify-content-between">
                                <div>
                                    <h1 className="fw-bold">派出任務</h1>
                                </div>
                                <div>
                                    <button type="button" className="btn btn-primary" onClick={this.toggle}>新增表單</button>
                                </div>
                            </div>
                        </div>
                        <div className="card-body">
                            <table className="table s-table table-bordered">
                                <thead>
                                    <tr style={{ textAlign: 'center' }}>
                                        <th scope="col">名稱</th>
                                        <th scope="col">類別</th>
                                        <th scope="col">進度</th>
                                        <th scope="col">負責人</th>
                                        <th scope="col">內容</th>
                                        <th scope="col">編輯</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {this.props.taskform_query.formdata.asign.map(item => (
                                        <tr key={item.id} style={{ textAlign: 'center', backgroundColor: item.belongToProgress === 3 ? "lightgrey" : "" }}>
                                            <td style={{ width: "20%" }}>{item.name}</td>
                                            <td style={{ width: "10%" }}>{item.typeName}</td>
                                            <td style={{ width: "15%" }}>
                                                <select className="form-select"
                                                    style={{ fontSize: '15px' }}
                                                    aria-label="Default select example"
                                                    value={item.belongToProgress}
                                                    onChange={(e) => { this.props.postFormChangeProgress(item.id, e.target.value); }}
                                                >
                                                    <option value="1">新專案</option>
                                                    <option value="2">進行中</option>
                                                    <option value="3">已完成</option>
                                                </select>
                                            </td>
                                            <td style={{ width: "10%" }}>{item.belongToLoginUserName}</td>
                                            <td style={{ textAlign: "left" }}>{item.description}</td>
                                            <td style={{ width: "10%" }}><button type="button" className="btn btn-primary" onClick={() => { this.props.postFormDelete(item.id); }} disabled={this.props.loginUser.user.roleNo === 1}>刪除</button></td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div className="card s-card s-card-mb shadow-sm mt-4">
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
                                    <tr style={{ textAlign: 'center' }}>
                                        <th scope="col">名稱</th>
                                        <th scope="col">類別</th>
                                        <th scope="col">進度</th>
                                        <th scope="col">發起人</th>
                                        <th scope="col">內容</th>
                                        <th scope="col">編輯</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {this.props.taskform_query.formdata.belong.map(item => (
                                        <tr key={item.id} style={{ textAlign: 'center', backgroundColor: item.belongToProgress === 3 ? "lightgrey" : "" }}>
                                            <td style={{ width: "20%" }}>{item.name}</td>
                                            <td style={{ width: "10%" }}>{item.typeName}</td>
                                            <td style={{ width: "15%" }}>
                                                <select className="form-select"
                                                    style={{ fontSize: '15px' }}
                                                    aria-label="Default select example"
                                                    value={item.belongToProgress}
                                                    onChange={(e) => { this.props.postFormChangeProgress(item.id, e.target.value); }}
                                                >
                                                    <option value="1">新專案</option>
                                                    <option value="2">進行中</option>
                                                    <option value="3">已完成</option>
                                                </select>
                                            </td>
                                            <td style={{ width: "10%" }}>{item.createByName}</td>
                                            <td style={{ textAlign: "left" }}>{item.description}</td>
                                            <td style={{ width: "10%" }}><button type="button" className="btn btn-primary" onClick={() => { this.props.postFormDelete(item.id); }} disabled={this.props.loginUser.user.roleNo === 1}>刪除</button></td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <Modal isOpen={this.state.isOpen} toggle={this.toggle}>
                    <ModalBody>
                        <form>
                            <div className="form-floating mb-3">
                                任務名稱 :
                                <input type="text" className="form-control" onChange={(e) => { this.props.addformTitle(e.target.value); }} />
                            </div>
                            <div className="form-floating mb-3">
                                任務重要度 :
                                <select className="form-select" style={{ fontSize: '20px' }} aria-label="Default select example">
                                    <option value="">請選擇...</option>
                                    <option value="1">緊急</option>
                                    <option value="2">優先</option>
                                    <option value="3">一般</option>
                                </select>
                            </div>
                            <div className="form-floating mb-3">
                                任務類別 :
                                <select className="form-select"
                                    style={{ fontSize: '20px' }}
                                    aria-label="Default select example"
                                    disabled={this.props.loginUser.user.roleNo !== 3}
                                    onChange={(e) => { this.props.addformType(e.target.value); }}
                                >
                                    <option value="1">錯誤回報</option>
                                    <option value="2">功能請求</option>
                                </select>
                            </div>
                            <div className="form-floating mb-3">
                                指派人員 :
                                <select className="form-select"
                                    style={{ fontSize: '20px' }}
                                    aria-label="Default select example"
                                    onChange={(e) => { this.props.addformUser(e.target.value); }}
                                >
                                    <option value="">請選擇...</option>
                                    <option value="ts001">王曉明</option>
                                    <option value="ts002">劉俊麟</option>
                                    <option value="ts003">金城武</option>
                                </select>
                            </div>
                            <div className="form-floating mb-3">
                                任務說明 :
                                <textarea className="form-control" aria-label="With textarea" placeholder="請輸入..." onChange={(e) => { this.props.addformDescription(e.target.value); }}></textarea>
                            </div>
                            <div className="checkbox mb-3">
                            </div>
                            <button className="w-100 btn btn-lg btn-primary" type="button" onClick={() => { this.props.postFormAdd(); }}>送出</button>
                        </form>
                    </ModalBody>
                    <ModalFooter>
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

export default connect((state) => state, store.actionCreators)(MyTask);
