##Tensorflow 설치

1. Install 링크: [Link](https://www.tensorflow.org/versions/r0.11/get_started/os_setup.html#download-and-setup)
2. pip 설치
    1) $ sudo easy_install pip
    2) $ sudo easy_install --upgrade six
3. 파이썬 설치 버젼 선택
    1) # Mac OS X, CPU only, Python 2.7: $ export TF_BINARY_URL=https://storage.googleapis.com/tensorflow/mac/cpu/tensorflow-0.11.0rc1-py2-none-any.whl
    2) # Mac OS X, GPU enabled, Python 2.7: $ export TF_BINARY_URL=https://storage.googleapis.com/tensorflow/mac/gpu/tensorflow-0.11.0rc1-py2-none-any.whl
    3) # Mac OS X, CPU only, Python 3.4 or 3.5: $ export TF_BINARY_URL=https://storage.googleapis.com/tensorflow/mac/cpu/tensorflow-0.11.0rc1-py3-none-any.whl
    4) # Mac OS X, GPU enabled, Python 3.4 or 3.5: $ export TF_BINARY_URL=https://storage.googleapis.com/tensorflow/mac/gpu/tensorflow-0.11.0rc1-py3-none-any.whl
4. 텐소플로우 설치
    1) # Python 2: $ sudo pip install --upgrade $TF_BINARY_URL
    2) # Python 3: $ sudo pip3 install --upgrade $TF_BINARY_URL
5. 