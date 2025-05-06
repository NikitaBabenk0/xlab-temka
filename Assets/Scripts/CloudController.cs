using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Test
{
    public class CloudController : MonoBehaviour
    {
        private int m_targetIndex = 0;
        private bool m_moved = false;
        public float moveSpeed = 0.001f;
        public Transform[] targets;
        public Cloud cloud;
        public void Action()
        {
            Debug.Log("Cloudcontroller - try", this);

            if (m_moved)
            { 
                return;
            }
            m_moved = true;
            cloud.StopFX();
            m_targetIndex++;
            if (m_targetIndex >= targets.Length) { m_targetIndex = 0; }
        }
        private void Update()
        { 
            if (!m_moved) { return; }

            Transform target = targets[m_targetIndex];
            Vector3 targetPosition = new Vector3(target.position.x, cloud.transform.position.y, target.position.z);
            Vector3 offset = (targetPosition - cloud.transform.position).normalized * moveSpeed * Time.deltaTime;
            if (Vector3.Distance(cloud.transform.position, targetPosition) < 0.1f)
            {
                cloud.transform.position = targetPosition;
                m_moved = false;
                cloud.PlayFX();
            }
            else { cloud.transform.Translate(offset); }
        }
    }
}
