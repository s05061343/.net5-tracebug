import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
    <div className="container-fluid">
        <div className="card s-card s-card-mb shadow-sm">
            <div className="card-header">
                <div className="d-flex justify-content-between">
                    <div>我的最愛</div>
                    <div><a className="btn btn-sm s-btn-outline-primary">設定</a><a className="btn btn-sm s-btn-outline-primary">編輯</a></div>
                </div>
            </div>
            <div className="card-body">
                <div className="s-list-btn">
                    <div className="s-item-btn">
                        <a><img src="../assets/style-se//img/btn-size.png" alt="" /><span className="s-text">文字</span></a>
                    </div>
                    <div className="s-item-btn">
                        <a><img src="../assets/style-se//img/btn-size.png" alt="" /><span className="s-text">１２３４５６７８９０１２３４５</span></a>
                    </div>
                    <div className="s-item-btn">
                        <a><img src="../assets/style-se//img/btn-size.png" alt="" /><span className="s-text">文字文字文字文字文字文字</span></a>
                    </div>
                    <div className="s-item-btn">
                        <a><img src="../assets/style-se//img/btn-size.png" alt="" /><span className="s-text">文字</span></a>
                    </div>
                    <div className="s-item-btn">
                        <a><img src="../assets/style-se//img/btn-size.png" alt="" /><span className="s-text">文字</span></a>
                    </div>
                    <div className="s-item-btn">
                        <a><img src="../assets/style-se//img/btn-size.png" alt="" /><span className="s-text">文字</span></a>
                    </div>
                    <div className="s-item-btn">
                        <a><img src="../assets/style-se//img/btn-size.png" alt="" /><span className="s-text">文字</span></a>
                    </div>
                    <div className="s-item-btn">
                        <a><img src="../assets/style-se//img/btn-size.png" alt="" /><span className="s-text">文字</span></a>
                    </div>
                </div>
            </div>
        </div>
        <div className="card s-card s-card-mb shadow-sm">
            <div className="card-body">
                SEOS問題回報表單：<a href="https://pse.is/DW9AB" target="_blank">https://pse.is/DW9AB</a>，已回報問題調整進度顯示：<a href="https://pse.is/G9URV" target="_blank">https://pse.is/G9URV</a>
            </div>
        </div>
        <div className="card s-card s-card-mb shadow-sm">
            <div className="card-header">標題文字</div>
            <div className="card-body">
                <table className="table s-table table-bordered">
                    <thead>
                        <tr>
                            <th scope="col">First</th>
                            <th scope="col">Last</th>
                            <th scope="col">Handle</th>
                            <th scope="col">Handle</th>
                            <th scope="col">Handle</th>
                            <th scope="col">Handle</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                        </tr>
                        <tr>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                        </tr>
                        <tr>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                            <td>TD</td>
                        </tr>
                        <tr>
                            <td>TD</td>
                            <td>TD</td>
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
);

export default connect()(Home);
