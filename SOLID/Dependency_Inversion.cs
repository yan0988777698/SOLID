using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion
{
    public enum RelationType
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class BadRelationships
    {
        private List<(Person, RelationType, Person)> _relations = new List<(Person, RelationType, Person)>();
        public List<(Person, RelationType, Person)> Relations => _relations;

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, RelationType.Parent, child));
            _relations.Add((child, RelationType.Child, parent));
        }
    }
    //===========================
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
    public class GoodRelationships : IRelationshipBrowser
    {
        private List<(Person, RelationType, Person)> _relations = new List<(Person, RelationType, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, RelationType.Parent, child));
            _relations.Add((child, RelationType.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return _relations.Where(x => x.Item1.Name == name && x.Item2 == RelationType.Parent)
                .Select(x => x.Item3);
        }
    }
}
