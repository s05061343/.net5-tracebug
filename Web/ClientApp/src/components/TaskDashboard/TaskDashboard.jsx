import * as React from 'react';
import { connect } from 'react-redux';
import * as store from '../../actions/task_actions.js';
import { Button, Modal, ModalBody, ModalFooter } from 'reactstrap';

class TaskDashboard extends React.PureComponent {
    state = {
        isOpen: false,
        belong: this.props.postFormQuery(),
        commen: this.props.postCommon()
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
                                    <button type="button" className="btn btn-primary" onClick={this.toggle}>新增任務</button>
                                </div>
                            </div>
                        </div>
                        <div className="card-body">
                            <table className="table s-table table-bordered">
                                <thead>
                                    <tr style={{ textAlign: 'center' }}>
                                        <th scope="col">名稱</th>
                                        <th scope="col">優先</th>
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
                                            <td style={{ width: "10%" }}>{item.name}</td>
                                            <td style={{ width: "15%" }}>
                                                <select className="form-select"
                                                    style={{ fontSize: '15px' }}
                                                    aria-label="Default select example"
                                                    value={item.priority}
                                                    onChange={(e) => { this.props.postFormChangePriority(item.id, e.target.value); }}
                                                >
                                                    {this.props.common.prioritys.map(item => (
                                                        <option key={item.id} value={item.id}>{item.name}</option>
                                                    ))}
                                                </select>
                                            </td>
                                            <td style={{ width: "10%" }}>{item.typeName}</td>
                                            <td style={{ width: "15%" }}>
                                                <select className="form-select"
                                                    style={{ fontSize: '15px' }}
                                                    aria-label="Default select example"
                                                    value={item.belongToProgress}
                                                    onChange={(e) => { this.props.postFormChangeProgress(item.id, e.target.value); }}
                                                >
                                                    {this.props.common.progress.map(item => (
                                                        <option key={item.id} value={item.id}>{item.name}</option>
                                                    ))}
                                                </select>
                                            </td>
                                            <td style={{ width: "10%" }}>{item.belongToLoginUserName}</td>
                                            <td style={{ textAlign: "left" }}>{item.description}</td>
                                            <td style={{ width: "10%" }}><button type="button" className="btn btn-primary" onClick={() => { this.props.postFormDelete(item.id); }} disabled={[2].includes(this.props.loginUser.user.roleNo)}>刪除</button></td>
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
                                        <th scope="col">優先</th>
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
                                            <td style={{ width: "10%" }}>{item.name}</td>
                                            <td style={{ width: "15%" }}>
                                                <select className="form-select"
                                                    style={{ fontSize: '15px' }}
                                                    aria-label="Default select example"
                                                    value={item.priority}
                                                    onChange={(e) => { this.props.postFormChangePriority(item.id, e.target.value); }}
                                                >
                                                    {this.props.common.prioritys.map(item => (
                                                        <option key={item.id} value={item.id}>{item.name}</option>
                                                    ))}
                                                </select>
                                            </td>
                                            <td style={{ width: "10%" }}>{item.typeName}</td>
                                            <td style={{ width: "15%" }}>
                                                <select className="form-select"
                                                    style={{ fontSize: '15px' }}
                                                    aria-label="Default select example"
                                                    value={item.belongToProgress}
                                                    onChange={(e) => { this.props.postFormChangeProgress(item.id, e.target.value); }}
                                                >
                                                    {this.props.common.progress.map(item => (
                                                        <option key={item.id} value={item.id}>{item.name}</option>
                                                    ))}
                                                </select>
                                            </td>
                                            <td style={{ width: "10%" }}>{item.createByName}</td>
                                            <td style={{ textAlign: "left" }}>{item.description}</td>
                                            <td style={{ width: "10%" }}><button type="button" className="btn btn-primary" onClick={() => { this.props.postFormDelete(item.id); }} disabled={[2].includes(this.props.loginUser.user.roleNo)}>刪除</button></td>
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
                                <select className="form-select"
                                    style={{ fontSize: '20px' }}
                                    aria-label="Default select example"
                                    onChange={(e) => { this.props.addformPriority(e.target.value); }}
                                >
                                    {this.props.common.prioritys.map(item => (<option key={item.id} value={item.id}>{item.name}</option>))}
                                </select>
                            </div>
                            <div className="form-floating mb-3">
                                任務類別 :
                                <select className="form-select"
                                    style={{ fontSize: '20px' }}
                                    aria-label="Default select example"
                                    onChange={(e) => { this.props.addformType(e.target.value); }}
                                >
                                    <option value="1">Bug Report</option>
                                    <option value="2" disabled={[1, 2].includes(this.props.loginUser.user.roleNo)}>Feature Request</option>
                                    <option value="3" disabled={[2, 3].includes(this.props.loginUser.user.roleNo)}>Test Case</option>
                                </select>
                            </div>
                            <div className="form-floating mb-3">
                                指派人員 :
                                <select className="form-select"
                                    style={{ fontSize: '20px' }}
                                    aria-label="Default select example"
                                    onChange={(e) => { this.props.addformUser(e.target.value); }}
                                >
                                    {this.props.common.users.map(item => (
                                        <option key={item.userId} value={item.userId}> {item.name}</option>
                                    ))}
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

export default connect((state) => state, store.actionCreators)(TaskDashboard);
