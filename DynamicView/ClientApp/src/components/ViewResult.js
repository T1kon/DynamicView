import React, { Component } from 'react';

export class ViewResult extends Component {
  static displayName = ViewResult.name;

  constructor(props) {
    super(props);
    this.state = { view: {}, loading: true };
  }

  componentDidMount() {
    this.getDynamicView();
  }

  static renderDynamicTable(view) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
              {
                  view.columns.map(column =>
                      <th>{column.caption}</th>
                  )
              }
          </tr>
        </thead>
        <tbody>
          {view.rows.map(row =>
            <tr>
                {
                    view.columns.map(column => column.name).map(columnName =>
                        <td>{row[columnName]}</td>
                    )
                }
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : ViewResult.renderDynamicTable(this.state.view);

    return (
      <div>
        <h1>Dynamic table</h1>
        {contents}
      </div>
    );
  }

  async getDynamicView() {
    const response = await fetch('api/view/');
    const data = await response.json();
    this.setState({ view: data, loading: false });
  }
}
