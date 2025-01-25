from transformers import BertTokenizer, BertModel
import torch
import json
from flask import Flask, request, jsonify

app = Flask(__name__)

# Загружаем модель и токенизатор
tokenizer = BertTokenizer.from_pretrained('bert-base-uncased')
model = BertModel.from_pretrained('bert-base-uncased')

@app.route('/embed', methods=['POST'])
def embed():
    data = request.json
    text = data['text']
    
    # Токенизация текста
    inputs = tokenizer(text, return_tensors='pt')
    
    # Получаем векторные представления
    with torch.no_grad():
        outputs = model(**inputs)
    
    # Получаем вектор [CLS] (первый токен)
    cls_vector = outputs.last_hidden_state[0][0].numpy().tolist()
    
    return jsonify({'vector': cls_vector})

if __name__ == '__main__':
    app.run(port=5000)