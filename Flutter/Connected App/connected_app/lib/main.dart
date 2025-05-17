
import 'package:flutter/material.dart';
import 'services/api_service.dart';
import 'services/http_service.dart';
import 'models/post.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(home: RequestDemo());
  }
}

class RequestDemo extends StatefulWidget {
  @override
  _RequestDemoState createState() => _RequestDemoState();
}

class _RequestDemoState extends State<RequestDemo> {
  String _response = 'No request made yet.';
  final HttpService _httpService = HttpService(apiService: ApiService(baseUrl: 'https://jsonplaceholder.typicode.com'));

  Future<void> getRequest() async {
    try {
      final post = await _httpService.getPost();
      setState(() {
        _response = 'GET Success:\nTitle: ${post.title}\nBody: ${post.body}';
      });
    } catch (e) {
      setState(() {
        _response = 'GET failed: $e';
      });
    }
  }

  Future<void> postRequest() async {
    final post = Post(userId: 1, id: 101, title: 'My Liege', body: 'This was posted with honor!');
    try {
      await _httpService.createPost(post);
      setState(() {
        _response = 'POST Success: ${post.title} created';
      });
    } catch (e) {
      setState(() {
        _response = 'POST failed: $e';
      });
    }
  }

  Future<void> putRequest() async {
    final post = Post(userId: 1, id: 1, title: 'My Liege (Edited)', body: 'This entire post has been replaced.');
    try {
      await _httpService.updatePost(post);
      setState(() {
        _response = 'PUT Success:\nPost updated';
      });
    } catch (e) {
      setState(() {
        _response = 'PUT failed: $e';
      });
    }
  }

  Future<void> patchRequest() async {
    final post = Post(userId: 1, id: 1, title: 'My Liege (Patched)', body: 'This title has been patched.');
    try {
      await _httpService.patchPost(post);
      setState(() {
        _response = 'PATCH Success:\nTitle updated';
      });
    } catch (e) {
      setState(() {
        _response = 'PATCH failed: $e';
      });
    }
  }

  Future<void> deleteRequest() async {
    try {
      await _httpService.deletePost(1);
      setState(() {
        _response = 'DELETE Success: Resource removed';
      });
    } catch (e) {
      setState(() {
        _response = 'DELETE failed: $e';
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('HTTP Request Demo')),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            Wrap(
              spacing: 10,
              runSpacing: 10,
              children: [
                ElevatedButton(onPressed: getRequest, child: Text('GET')),
                ElevatedButton(onPressed: postRequest, child: Text('POST')),
                ElevatedButton(onPressed: putRequest, child: Text('PUT')),
                ElevatedButton(onPressed: patchRequest, child: Text('PATCH')),
                ElevatedButton(onPressed: deleteRequest, child: Text('DELETE')),
              ],
            ),
            SizedBox(height: 20),
            Expanded(
              child: SingleChildScrollView(
                child: Text(_response, style: TextStyle(fontSize: 14)),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
