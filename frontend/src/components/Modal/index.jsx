import React from 'react'
import { Modal
} from 'antd'

const ModalMessage = ({ title, message, isModalVisible, handleCancel, handleOk }) => {
  return (
    <>
      <Modal
        title={title}
        visible={isModalVisible}
        onOk={handleOk}
        onCancel={handleCancel}
      >
        <p>{message}</p>
      </Modal>
    </>
  );
}

export default ModalMessage