'use client'
import React, { useEffect, useState } from 'react';
import {
  DesktopOutlined,
  DownloadOutlined,
  ExclamationCircleOutlined,
  FileOutlined,
  InfoCircleOutlined,
  PauseCircleOutlined,
  PieChartOutlined,
  PlayCircleOutlined,
  TeamOutlined,
  UpCircleOutlined,
  UserOutlined,
} from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Breadcrumb, Button, Card, Col, Layout, Menu, Row, Table, Typography, theme } from 'antd';
import { Switch } from 'antd';
import { Line } from 'react-chartjs-2';
import 'chart.js';
import 'react-chartjs-2';
const { Title } = Typography;
import Chart from 'chart.js/auto';
import {CategoryScale} from 'chart.js'; 
Chart.register(CategoryScale);

const { Header, Content, Footer, Sider } = Layout;

type MenuItem = Required<MenuProps>['items'][number];

function getItem(
  label: React.ReactNode,
  key: React.Key,
  icon?: React.ReactNode,
  children?: MenuItem[],
): MenuItem {
  return {
    key,
    icon,
    children,
    label,
  } as MenuItem;
}

const items: MenuItem[] = [
  getItem('Option 1', '1', <PieChartOutlined />),
  getItem('Option 2', '2', <DesktopOutlined />),
  getItem('User', 'sub1', <UserOutlined />, [
    getItem('Tom', '3'),
    getItem('Bill', '4'),
    getItem('Alex', '5'),
  ]),
  getItem('Team', 'sub2', <TeamOutlined />, [getItem('Team 1', '6'), getItem('Team 2', '8')]),
  getItem('Files', '9', <FileOutlined />),
];

const columns:any = [
  // { title: 'Processo', dataIndex: 'processo', key: 'processo', align: 'center' },
  { title: 'Última Execução', dataIndex: 'lastExecution', key: 'lastExecution', align: 'center' },
  { title: 'Próxima Execução', dataIndex: 'nextExecution', key: 'nextExecution', align: 'center' },
  // { title: 'Status', dataIndex: 'status', key: 'status', align: 'center' },
  {
    title: 'Ativado/Desativado',
    dataIndex: 'ativadoDesativado',
    key: 'lastStatus',
    align: 'center',
    render: (text:any, record:any) => (
      <Switch
        checked={text === 1}
      />
    ),
  },
  // { title: 'Log', dataIndex: 'logUrl', key: 'logUrl', align: 'center' },
  { title: 'Último Status', dataIndex: 'lastStatus', key: 'lastStatus', align: 'center',   render: (text: any) => (
    <LineChart data={chartData} />
  ), },
];
const LineChart = ({ data }: any) => (
  <Line
    data={data}
    options={{
      scales: {
        xAxes: [{
          type: 'category',
          labels: ['Label'],
        }] as any,
        yAxes: [{
          ticks: {
            beginAtZero: true,
          },
        }] as any,
      },
      maintainAspectRatio: false,
      responsive: true,
    }}
    height={200}
    width={200}
  />
);

const chartData = {
  labels: ['Label'],
  datasets: [{
    label: 'Status',
    data: [1, 0, 1, 0, 1, 0], 
    fill: false,
    backgroundColor: "rgb(255, 99, 132)",
    borderColor: "rgba(255, 99, 132, 0.2)"
  }]
};

const App: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:8080/api/Dashboard/ListDashboard');
        const result = await response.json();
        console.log(result)
        setData(result);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, []);

  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();
  
  const renderSwitch = (status: any) => (
    <Switch checked={status === "1"} />
    
  );
  
  const handleDownloadClick = (logUrl: string) => {
    console.log(logUrl)
    window.open(logUrl, '_blank');
  };

  const StatusIcon = ({ lastStatus }:any) => {
    switch (lastStatus) {
      case '1':
        return <PlayCircleOutlined style={{ fontSize: '30px', marginRight: '5px', color: 'green' }} />;
      case '0':
        return <PauseCircleOutlined style={{ fontSize: '30px', marginRight: '5px', color: 'orange' }} />;
      case '2':
        return <ExclamationCircleOutlined style={{ fontSize: '30px', marginRight: '5px', color: 'orange' }} />;
    }
  };
 
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
        <div className="demo-logo-vertical" />
        <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline" items={items} />
      </Sider>
      <Layout>
        <Header style={{ padding: 0, background: colorBgContainer }} />
        <Content style={{ margin: '0 16px' }}>
          <Breadcrumb style={{ margin: '16px 0' }}>
            {/* <Breadcrumb.Item>User</Breadcrumb.Item>
            <Breadcrumb.Item>Bill</Breadcrumb.Item> */}
          </Breadcrumb>
          <div
            style={{
              padding: 24,
              minHeight: 360,
              background: colorBgContainer,
              borderRadius: borderRadiusLG,
            }}
          >
            {data.map((item: any) => (
              <Row key={item.key}>
                <Col span={24}>
                  <Card
                    title={
                      <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
                        <div style={{ display: 'flex', alignItems: 'center' }}>
                          <StatusIcon lastStatus={item.lastStatus}/>
                          <h1><b>{item.process.name}</b></h1>
                        </div>
                        <Button type="primary" style={{ float: 'right' }} onClick={() => handleDownloadClick(item.logUrl)}>
                          <DownloadOutlined style={{ fontSize: '20px' }} />
                        </Button>
                      </div>
                    }
                  >
                    <Table
                      columns={columns.map((col: any) => {
                        if (col.dataIndex === 'ativadoDesativado') {
                          return {
                            ...col,
                            render: () => renderSwitch(item.lastStatus
                              ),
                          };
                        }
                        return col;
                      })}
                      dataSource={[item]}
                      pagination={false}
                    />
                  </Card>
                </Col>
              </Row>
            ))}
          </div>
        </Content>
        <Footer style={{ textAlign: 'center' }}>Ant Design ©2023 Created by Ant UED</Footer>
      </Layout>
    </Layout>
  );
};

export default App;
