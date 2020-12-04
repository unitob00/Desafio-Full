import React, { useState } from 'react'
import { Redirect } from 'react-router-dom'

import {
  Form, Input, Button, Card, Table, InputNumber
} from 'antd'

import { postData } from '../../services/api'

import ModalMessage from '../Modal'

import './style.css'

const FormSizeDemo = () => {
  const [parcelas, setParcelas] = useState([]);
  const [showparcela, setShowParcelas] = useState(false);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [modalTitle, setModalTitle] = useState('');
  const [modalMessage, setModalMessage] = useState('');
  const [cadastro, setCadastro] = useState(false);

  const showModal = () => {
    setIsModalVisible(true);
  };

  const handleOk = () => {
    setIsModalVisible(false);
    if (cadastro) {
      return <Redirect to="/Listagem"/>
    }
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };
  
  const showParcela = () => {
    setShowParcelas(!showparcela);
  }

  const handleOnFinish = (values) => {
   if (parcelas.length > 0) {
    postData({
      ...values,
      parcelas,
    }).then((resp) => {
      setCadastro(true);
      setModalTitle('Cadastrado com sucesso');
      setModalMessage('');
      showModal();
    })
    .catch((error) => {
      setModalTitle('Erro');
      setModalMessage(error.message);
      showModal();
    });
   } else {
     setModalTitle('Erro');
     setModalMessage('Para adicionar título é obrigatorio adicionar parcela');
     showModal();
   }
  };

  const handleAddParcelas = (values) => {
    const parcela = {
      values,
    };
    setParcelas((prevState) => ([
      ...prevState,
      parcela.values,
    ]));
  };

  const columns = [
    {
      title: 'Número da Parcela',
      dataIndex: 'numeroParcela',
      key: 'numeroParcela',
    },
    {
      title: 'Data do Vencimento',
      dataIndex: 'dataVencimento',
      key: 'dataVencimento',
    },
    {
      title: 'Valor da Parcela',
      dataIndex: 'valorParcela',
      key: 'valorParcela',
    },
  ];

  return (
    <>
      <div className="content">
        <Card title="Dados do Título" style={{ width: 800 }}>
          <Form
            labelCol={{ span: 4 }}
            wrapperCol={{ span: 14 }}
            layout="horizontal"
            onFinish={handleOnFinish}
          >
            <Form.Item label="Número do titulo" colon name="numeroTitulo" rules={[{ required: true, message: 'Número do título Obrigatorio' }]} >
              <Input type="number" />
            </Form.Item>
            <Form.Item label="Nome" name="nome" rules={[{ required: true, message: 'Nome é Obrigatorio' }]} >
              <Input />
            </Form.Item>
            <Form.Item label="CPF" name="cpf" rules={[{ required: true, message: 'CPF é Obrigatorio' }]}>
              <Input maxLength="11" minLength="11" />
            </Form.Item>
            <Form.Item  label="Valor da multa" name="juros" rules={[{ required: true, message: 'Juros do título é obrigatorio'}]}>
              <InputNumber defaultValue={0}
                            min={0}
                            max={100}
                            formatter={value => `${value}%`}
                            parser={value => value.replace('%', '')}/>
            </Form.Item>
            <Form.Item label="Valor do juros" name="multa" rules={[{ required: true, message: 'Multa do título é obrigatorio'}]}>
            <InputNumber defaultValue={0}
                         min={0}
                         max={100}
                         formatter={value => `${value}%`}
                         parser={value => value.replace('%', '')}/>
            </Form.Item>
            <Button disabled={parcelas.length <= 0} htmlType="submit">Salvar</Button>
            <Button onClick={showParcela}>Adicionar Nova parcela</Button>
          </Form>
        </Card>
        {
          showparcela && (
            <Card title="Dados da Parcela" style={{ width: 450 }}>
              <Form
                labelCol={{ span: 14 }}
                wrapperCol={{ span: 10 }}
                layout="horizontal"
                onFinish={handleAddParcelas}
              >
                <Form.Item label="Numero da parcela" name="numeroParcela" rules={[{ required: true, message: 'Número da parcela é obrigatorio'}]}>
                  <Input type="number" />
                </Form.Item>
                <Form.Item label="Data do vencimento" name="dataVencimento" rules={[{ required: true, message: 'Vencimento da parcela é obrigatorio'}]}>
                  <Input type="date" />
                </Form.Item>
                <Form.Item label="Valor da parcela" name="valorParcela" rules={[{ required: true, message: 'Valor da parcela é obrigatorio'}]}>
                <InputNumber/>
                </Form.Item>
                <Button htmlType="submit">Salvar</Button>
              </Form>
            </Card>
          )
        }
      </div>
      <div className="listParcelas">
        <Table dataSource={parcelas} columns={columns}/>
      </div>
      <ModalMessage title={modalTitle} message={modalMessage} showModal={showModal} isModalVisible={isModalVisible} handleCancel={handleCancel} handleOk={handleOk}/>
    </>
  );
};

export default FormSizeDemo;
