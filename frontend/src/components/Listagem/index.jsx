import React, { useEffect, useState } from 'react'

import { getData } from '../../services/api'

import { Table
} from 'antd'


const Listagem = () => {
  const [project, setProject] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    async function Listar() {
      var resp = await getData();
      setProject(resp.data);
    }

    Listar();
  
  }, []);

  const columns = [
    {
      title: 'Numero do título',
      dataIndex: 'numeroTitulo',
      key: 'numeroTitulo',
    },
    {
      title: 'Nome',
      dataIndex: 'nome',
      key: 'nome',
    },
    {
      title: 'CPF',
      dataIndex: 'cpf',
      key: 'cpf',
    },
    {
      title: 'Quantidade de parcelas',
      dataIndex: 'quantidadeParcelas',
      key: 'quantidadeParcelas',
    },
    {
      title: 'Valor Original',
      dataIndex: 'valorOriginal',
      key: 'valorOriginal',
    },
    {
      title: 'Dias em Atraso',
      dataIndex: 'diasAtraso',
      key: 'diasAtraso',
    },
    {
      title: 'Valor Atualizado',
      dataIndex: 'valorAtualizado',
      key: 'valorAtualizado',
    }
  ];
  
  return (
     <Table dataSource={project} columns={columns} />
  );
};

export default Listagem