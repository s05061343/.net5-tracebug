import * as React from 'react';
import { connect } from 'react-redux';
import * as store from '../../actions/task_actions.js';

class AdminTool extends React.PureComponent {
    render() {
        return (
            <React.Fragment>
                <div className="container-fluid">
                    <div className="text-center">
                        <main className="form-signin">
                            <form>
                                <h1>建立新用戶</h1>
                                <div className="form-floating">
                                    帳號 :
                                    <input type="email" className="form-control" id="floatingInput"
                                        onChange={(e) => { this.props.setNewUserId(e.target.value); }} />
                                </div>
                                <div className="form-floating">
                                    密碼 :
                                    <input type="password" className="form-control" id="floatingPassword"
                                        onChange={(e) => { this.props.setNewPassword(e.target.value); }} />
                                </div>
                                <div className="form-floating">
                                    姓名 :
                                    <input type="email" className="form-control" id="floatingInput"
                                        onChange={(e) => { this.props.setNewName(e.target.value); }} />
                                </div>
                                <div className="form-floating">
                                    身分 :
                                    <select className="form-select"
                                        style={{ fontSize: '20px' }}
                                        aria-label="Default select example"
                                        onChange={(e) => { this.props.setNewRole(e.target.value); }}
                                    >
                                        {this.props.common.roles.map(item => (<option key={item.id} value={item.id}> {item.name}</option>))}
                                    </select>
                                </div>
                                <div className="checkbox mb-3">
                                </div>
                                <button className="w-100 btn btn-lg btn-primary" type="button" onClick={() => { this.props.postAddUser(); }}>建立</button>
                            </form>
                        </main>
                    </div>
                </div>
            </React.Fragment>
        );
    }
};

export default connect((state) => state, store.actionCreators)(AdminTool);
